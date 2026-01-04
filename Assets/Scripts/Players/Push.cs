using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class Push : MonoBehaviour
{
    public int bashForce = 10;
    public float waitTime = 0.2f;

    private Rigidbody2D rb;
    private float originGravity;
    private bool isAiming=false;

    public GameObject arrowUI;

    public PlayerMovement moveScript;

    public ManaManager manaManager;
    public int mana;

    public PolygonCollider2D atkCollider; // 공격
    public LayerMask breakableLayer;
    public TextMeshProUGUI manaHud;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originGravity = rb.gravityScale;
        if (arrowUI != null) arrowUI.SetActive(false);
        
    }
    void Update()
    {



        // 1. 우클릭을 누르는 순간 (조준 시작)
        if (Input.GetMouseButtonDown(1)&& manaManager.UseEnergy(mana)) // 1은 마우스 우클릭
        {
            StartAiming();
        }

        // 3. 우클릭을 떼는 순간 (발사 및 정상화)
        if (Input.GetMouseButtonUp(1) && isAiming)
        {
            EndAiming();
        }
        // 조준 중일 때 화살표 회전 로직
        if (isAiming && arrowUI != null)
        {
            RotateArrow();
        }
    }

    void RotateArrow()
    {
        // 1. 마우스 위치 계산 (이전에 썼던 월드 좌표 변환)
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        // 2. 방향 벡터 구하기
        Vector2 direction = (Vector2)worldMousePos - (Vector2)transform.position;

        // 3. 각도 계산 (Atan2 함수 사용)
        // Rad2Deg를 곱해 유니티 각도(Degree)로 변환합니다.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 4. 화살표 회전 적용
        arrowUI.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void StartAiming()
    {
        
        if (arrowUI != null) arrowUI.SetActive(true);
        isAiming = true;
        Time.timeScale = 0.01f; // 시간 정지

        rb.velocity = Vector2.zero; // 속도 정지
        rb.gravityScale = 0f;       // 중력 정지

        Debug.Log("조준 상태 진입!");
    }

    void EndAiming()
    {
        

        isAiming = false;
        Time.timeScale = 1f; // 시간 정상화
        rb.gravityScale = originGravity; // 중력 복구

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z; // 보통 카메라가 -10에 있으므로 10이 들어감

        // 1. 마우스 월드 좌표 구하기
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        mouseWorldPos.z = 0f; // 2D이므로 z축은 0으로 고정

        // 2. 방향 계산 (목표 지점 - 내 지점) -> 정규화(.normalized)
        Vector2 mypos = rb.position;
        Vector2 launchDirection = ((Vector2)mouseWorldPos - mypos).normalized;
        int retain = bashForce;
        attack();
        
        if (arrowUI != null) arrowUI.SetActive(false);
        if (moveScript != null)
        {
            StartCoroutine(BashControlRoutine(moveScript, launchDirection));
        }
        bashForce = retain;

    }

    // 강타 동안만 잠시 이동을 막아주는 코루틴
    IEnumerator BashControlRoutine(PlayerMovement move, Vector2 dir)
    {
        move.isBashing = true; // 이동 차단 시작
        rb.velocity = dir * bashForce; // 실제 발사
        isAiming = false;
        manaManager.ReduceEnergy(mana);
        // 0.2~0.3초 정도가 '오리'의 날아가는 느낌을 주기에 적당합니다.
        yield return new WaitForSeconds(waitTime);

        move.isBashing = false; // 이동 차단 해제
    }

    void attack()
    {
        // 1. 삼각형 콜라이더와 겹치는 모든 콜라이더를 가져올 리스트 준비
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(breakableLayer); // 장애물 레이어만 걸러내기
        filter.useTriggers = true;

        // 2. 삼각형 범위 내에 있는 충돌체 찾기
        int hitCount = atkCollider.OverlapCollider(filter, results);

        // 3. 찾은 물체들 파괴
        for (int i = 0; i < hitCount; i++)
        {
            Collider2D hit = results[i];

            // A. 보스를 맞춘 경우
            if (hit.CompareTag("Boss"))
            {
                
                unit bossUnit = hit.GetComponent<unit>();
                if (bossUnit != null)
                {
                    StartCoroutine(BossFinisher(bossUnit));
                }
            }
            // B. 일반 장애물(총알 포함)인 경우
            else
            {
                Destroy(hit.gameObject);
                Debug.Log(hit.name + " 파괴됨!");
                bashForce = 5;
            }
        }
        IEnumerator BossFinisher(unit bossUnit)
        {
            Time.timeScale = 0.01f;
            int time = manaManager.energy;
            float breaker = 0.002f;
            manaManager.enabled = false;
            for (int j = 0; j < time; j++)
            {
                manaHud.text = (time - j).ToString();
                yield return new WaitForSeconds(breaker);
            }
            manaHud.color = Color.red;
            manaHud.text = 10.ToString();

            for (int j = 0; j < time; j++)
            {
                manaHud.text = (j*10).ToString();
                yield return new WaitForSeconds(0.001f);
            }
            bool isdead = bossUnit.TakeDamage(time * 10);

            SceneManager.LoadScene("Scenes_Talk"); //공격 끝나고 씬 전환
            Time.timeScale = 1f;
        }



    }


}