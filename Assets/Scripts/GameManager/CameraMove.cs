using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    public float cameraSpeed = 0.7f;
    public GameObject player;
    public bool cameraEnd = false;
    bool timeload = true;

    public TextMeshProUGUI timerUI;
    int count = 0;

    private void Awake() // 맨처음 카메라 위치 초기화
    {
        Vector2 dir1 = player.transform.position - this.transform.position;
        Vector2 moveVector = new Vector2(dir1.x, 0);
        this.transform.Translate(moveVector);
    }

    private void Update()
    {
        if (this.transform.position.x >= 72f) // x가 72면(현 상황 보스 보이는 위치) 카메라 멈춤
        {
            cameraEnd = true;
            S_timer();
        }

        if (cameraEnd == false)
        {
            Vector2 moveVector = new Vector2(Time.deltaTime * cameraSpeed, 0);
            this.transform.Translate(moveVector);
        }
    }

    //나중에 코드 분리
    public void S_timer()
    {
        if (count < 10 && timeload)
            StartCoroutine(StartTimer());
        else if (count >= 10 && timeload)
            SceneManager.LoadScene("Scenes_Talk");
         
    }

    IEnumerator StartTimer()
    {
        timeload = false;
        timerUI.text = count.ToString();
        yield return new WaitForSeconds(1f);
        count += 1;
        timeload = true;
    }

}