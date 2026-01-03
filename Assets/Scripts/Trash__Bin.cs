using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash__Bin : MonoBehaviour
{
    public LayerMask breakableLayer;
    public BoxCollider2D boxCollider; 
        
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        trash();
    }
    void trash()
    {
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(breakableLayer); // 장애물 레이어만 걸러내기
        filter.useTriggers = true;

        // 2. 삼각형 범위 내에 있는 충돌체 찾기
        int hitCount = boxCollider.OverlapCollider(filter, results);

        // 3. 찾은 물체들 파괴
        for (int i = 0; i < hitCount; i++)
        {
            Destroy(results[i].gameObject);
            Debug.Log(results[i].name + " 파괴됨!");
        }
    }
}
