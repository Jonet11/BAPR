using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public GameObject player;

    private void Update()
    {
        Vector2 dir = player.transform.position - this.transform.position;
        Vector2 moveVector = new Vector2(dir.x * cameraSpeed * Time.deltaTime, this.transform.position.y);
        this.transform.Translate(moveVector);
    }
}