using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float cameraSpeed = 0.7f;
    public GameObject player;
    bool cameraEnd;
    public GameObject Camera;

    private void Awake() // 맨처음 카메라 위치 초기화
    {
        Vector2 dir1 = player.transform.position - this.transform.position;
        Vector2 moveVector = new Vector2(dir1.x, 0);
        this.transform.Translate(moveVector);

        cameraEnd = Camera.GetComponent<CameraMove>().cameraEnd;
    }

    private void Update()
    {
        cameraEnd = Camera.GetComponent<CameraMove>().cameraEnd;

        if (cameraEnd == false)
        {
            Vector2 moveVector = new Vector2(Time.deltaTime * cameraSpeed, 0);
            this.transform.Translate(moveVector);
        }
    }
}
