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

    TextMeshProUGUI logue;


    void Awake()
    {
        
        obj_text = GameObject.Find("Boss_Talk_Text");
        Text_Canvas = GameObject.Find("Text_Canvas");
        Main_Canvas = GameObject.Find("Canvas");

        logue = obj_text.GetComponent<TextMeshProUGUI>();
        Text_Canvas.SetActive(false);
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

        logue.text = "Hello";
        yield return new WaitForSeconds(2f);
        logue.text = "I am rock.";
        yield return new WaitForSeconds(2f);
        logue.text = "ha ha";
        yield return new WaitForSeconds(2f);

        End_text();
    }

    public IEnumerator Talking2()
    {
        Start_text();
        logue.text = "hello";

        yield return new WaitForSeconds(2f);
        End_text();
    }

    void Start_text()
    {
        Main_Canvas.SetActive(false); // 메인 ui 비활성화
        Text_Canvas.SetActive(true); // 텍스트 ui 생성
    }

    void End_text()
    {
        Main_Canvas.SetActive(true);
        Text_Canvas.SetActive(false);
    }

}
