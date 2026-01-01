using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public Transform firePoint;
    public float bulletSpeed = 7f;

    void Start()
    {
        StartCoroutine(BossPatternRoutine());
    }
    IEnumerator BossPatternRoutine()
    {
        while (true) // 죽기 전까지 무한 반복
        {
            // 패턴 1: 3연사
            yield return StartCoroutine(Pattern_1());
            yield return new WaitForSeconds(2f);

            // 패턴 2: 큰 거 한방
            yield return StartCoroutine(Pattern_2());
            yield return new WaitForSeconds(3f);
        }
        IEnumerator Pattern_1()
        {
            for (int i = 0; i < 3; i++)
            {
                Shoot(Vector2.left); // 왼쪽 방향으로 발사
                yield return new WaitForSeconds(0.5f);
            }
        }
        IEnumerator Pattern_2()
        {
            for (int i = 0; i < 3; i++)
            {
                Shoot(Vector2.left); // 왼쪽 방향으로 발사
                yield return new WaitForSeconds(0.5f);
            }
        }
        void Shoot(Vector2 direction)
        {
            GameObject bullet = Instantiate(bulletPrefab1, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * bulletSpeed;
        }
    }
}
