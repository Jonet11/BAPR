using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class BossTalk : MonoBehaviour
{
    GameObject obj_text;
    GameObject Text_Canvas;
    GameObject Main_Canvas;

    BattleSystem BattleSystem;

    TextMeshProUGUI logue;

    public bool ready_text;

    void Awake()
    {
        obj_text = GameObject.Find("Boss_Talk_Text");
        Text_Canvas = GameObject.Find("Text_Canvas");
        Main_Canvas = GameObject.Find("Canvas");

        BattleSystem = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();

        logue = obj_text.GetComponent<TextMeshProUGUI>();
        Text_Canvas.gameObject.SetActive(false);
        ready_text = true;
    }

    public IEnumerator Talking0()
    {
        Start_text();
        logue.text = "Why?";
        yield return new WaitForSeconds(2f);

        End_text();
        yield break;
    }

    // Start is called before the first frame update
    public IEnumerator Talking1()
    {
        Start_text();
        ready_text = false;

        logue.text = "Hello";
        yield return new WaitForSeconds(2f);
        logue.text = "I am rock.";
        yield return new WaitForSeconds(2f);
        logue.text = "ha ha";
        yield return new WaitForSeconds(2f);

        End_text();
        ready_text = true;
    }

    public IEnumerator Talking2()
    {
        Start_text();
        ready_text = false;
        logue.text = "hello";

        yield return new WaitForSeconds(2f);
        End_text();
        ready_text = true;
    }
    //프리팹 위치 이동하려다가 실패함 나중에 고치기
    void Start_text()
    {
        Main_Canvas.gameObject.SetActive(false); // 메인 ui 비활성화
        Text_Canvas.gameObject.SetActive(true); // 텍스트 ui 생성
    }

    void End_text()
    {
        Main_Canvas.gameObject.SetActive(true);
        Text_Canvas.gameObject.SetActive(false);
    }

}
