using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Base : MonoBehaviour
{
    public int damage;

    public LayerMask breakableLayer;
    public BoxCollider2D boxCollider;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. 플레이어에게 닿았는지 체크 (Tag 사용)
        if (collision.CompareTag("Player"))
        {
            unit unit = collision.GetComponent<unit>();
            bool a = unit.TakeDamage(damage); 

            Debug.Log("플레이어가 총알에 맞았습니다!");
            Destroy(gameObject);

        }

        // 2. 만약 벽(Ground)에 닿아도 없어지게 하고 싶다면
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Trash Bin"))
        {
            Destroy(gameObject);
        }
    }
}
