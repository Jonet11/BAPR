using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 4; //이동속도
    private Rigidbody2D body;

    public bool isBashing = false;//push판정
    public float acceleration = 50f; // 가속도 (높을수록 반응이 빠름)
    public float decceleration = 40f; // 감속도 (높을수록 빨리 멈춤)

    private bool grounded; //땅에 닿았는지 안닿았는지

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isBashing)//push중인지 아닌지
        {
            Move();
            if (Input.GetKeyDown(KeyCode.W) && grounded)
            {
                Jump();
            }
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
        // 1. 목표 속도 계산
        float targetXVelocity = Input.GetAxisRaw("Horizontal") * speed;

        // 2. 가속/감속 수치 결정 (입력이 있으면 가속도, 없으면 감속도 사용)
        float accelRate = (Mathf.Abs(targetXVelocity) > 0.01f) ? acceleration : decceleration;

        // 3. 현재 속도에서 목표 속도로 'accelRate'만큼만 변화시킴
        float newX = Mathf.MoveTowards(body.velocity.x, targetXVelocity, accelRate * Time.deltaTime);

        // 4. 최종 속도 대입 (Y축은 건드리지 않음으로써 강타의 Y축 힘 보존)
        body.velocity = new Vector2(newX, body.velocity.y);
        

        //body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y); //기본적인 a,d키 움직임(지금은 방향키로도 움직임)

        if (Input.GetKey(KeyCode.S)) //s키 누르면 아래로 빠르게 내려감
                                     //위에 코드 응용해서 아래로 내려가는것도 꾹누르면 빨라지게 바꾸면 좋을듯?
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
