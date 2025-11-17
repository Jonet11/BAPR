using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class BossTalk : MonoBehaviour
{
    GameObject Text_Canvas;
    GameObject Main_Canvas;
    BattleSystem BS;

    TextMeshProUGUI logue;


    void Awake()
    {
        
        
        BS = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
        Text_Canvas = BS.Text_Canvas;
        Main_Canvas = BS.Main_Canvas;
        logue = BS.Bosslogue;

        Text_Canvas.SetActive(false);
    }

    //대사 출력
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
