using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusHub : MonoBehaviour
{
    BattleSystem BS;
    GameObject Status_Canvas;
    Image illust;
    TextMeshProUGUI text;

    private void Awake()
    {
        BS = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
        Status_Canvas = BS.Status_Canvas;

        //캔버스의 0번(첫번째)자식 가져오기(아래의 경우는 status_IL)
        illust = Status_Canvas.transform.GetChild(0).gameObject.GetComponent<Image>();
        text = Status_Canvas.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
    }
    //근데 status를 갖고있는 유닛이 2개라서 이렇게 나누는게 의미가 있나? 싶긴함
    //나중에 하나로 합치고 battlesystem의 버튼도 하나의 함수로 합치기
    //(지금은 컬러로 나눠서 2개인데 나중에는 각각의 스프라이트 가져오기로)
    public void Boss(unit bossunit)
    {
        illust.color = new Color(1, 0, 0);
        text.text = $"waterfall_armor : {bossunit.waterfall_armor}\n" +
                    $"high_tide : {bossunit.high_tide}\n" +
                    $"adminstrator : {bossunit.administrator}";

    }

    public void Player(unit playerunit)
    {
        illust.color = new Color(0, 0, 1);
        text.text = $"buff1 : {playerunit.buff1}\n" +
                    $"buff2 : {playerunit.buff2}\n" +
                    $"buff3 : {playerunit.buff3}";

    }
}
