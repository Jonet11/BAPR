using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkillErk", menuName = "Skills/Skill_Erk")]
public class Skill_Erk :SkillBase
{
    public int bullet = 2;
    public int damage = 10;
    //private bool isAiming = false;
    
    public unit bossUnit;
    public GameObject shot;
    public override void Execute(GameObject caster)
    {
        Debug.Log("스킬 Execute 실행됨!");

        // [빠른 구현] 실행 시점에 씬에서 직접 찾기
        /*if (shot == null)
            shot = GameObject.FindWithTag("Shot");
        Debug.Log("Shot 실행됨!");// 씬에 있는 실제 오브젝트 이름으로 바꾸세요
        */
        if (bossUnit == null) { 

            GameObject bossObj = GameObject.FindWithTag("Boss");
            Debug.Log("보스를 찾았습니다: " + bossObj.name); // <-- 추가
            bossUnit = bossObj.GetComponent<unit>();
        }

       
            Debug.Log("코루틴 시작 직전!"); // <-- 추가
        if (bullet == 0) {
            Debug.Log("총알 없엉!"); // <-- 추가
        }
        else
        {
            bullet--;
            caster.GetComponent<MonoBehaviour>().StartCoroutine(Aiming(caster));
        }

    }
    IEnumerator Aiming(GameObject caster)
    {

        // 캔버스를 찾아서 그 자식으로 생성
        Transform canvasTransform = GameObject.FindObjectOfType<Canvas>().transform;
        GameObject shotInstance = Instantiate(shot, canvasTransform);

        // 위치와 크기 초기화 (중앙에 1:1 크기로)
        RectTransform rect = shotInstance.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector2.zero;
        shotInstance.transform.localScale = Vector3.one;

        // if (arrowUI != null) arrowUI.SetActive(true);
        //isAiming = true;
        Time.timeScale = 0.001f; // 시간 정지
        
        

        yield return new WaitForSecondsRealtime(0.05f);
        Destroy(shotInstance);
        yield return new WaitForSecondsRealtime(0.05f);
        bossUnit.TakeDamage(damage);
        Time.timeScale = 1f;

    }

    

}
