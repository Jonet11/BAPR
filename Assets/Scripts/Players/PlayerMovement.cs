using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 4; //이동속도
    private Rigidbody2D body;

    private bool grounded; //땅에 닿았는지 안닿았는지

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

        if(Input.GetKey(KeyCode.W) && grounded)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //다른 물체에 닿았을때
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }

    private void Move()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y); //기본적인 a,d키 움직임(지금은 방향키로도 움직임)

        if(Input.GetKey(KeyCode.S)) //s키 누르면 아래로 빠르게 내려감
        {
            body.velocity = new Vector2(body.velocity.x, -speed);
        }
    }

    private void Jump()
    {
        grounded = false;
        body.velocity = new Vector2(body.velocity.x, (speed + 2));
    }

}
