using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitedCamera : MonoBehaviour
{
    public GameObject player;
    public GameObject AttackDelete;
    Transform Delete;

    public unit player_hp;

    private Camera mainCamera;

    Vector2 min;
    Vector2 max;
    private void Start()
    {
        mainCamera = Camera.main; // 게임에서 메인 카메라 가져오기
        Delete = AttackDelete.gameObject.transform;
        min = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        //max = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

    }
    // Update is called once per frame
    private void Update()
    {
        FindPlayerPosition();
    }


    public void FindPlayerPosition()
    {
        min = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        //max = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

        if (min.x > player.transform.position.x || min.y > player.transform.position.y)
        {
            SetPlayerPosition();
        }
    }

    public void SetPlayerPosition() //위치 초기화
    {
        Vector2 dir2 = new Vector2(Delete.position.x + 5, Delete.position.y + 8);
        player.transform.position = dir2;
        player_hp.TakeDamage(10);
        Debug.Log("exit");
    }
}
