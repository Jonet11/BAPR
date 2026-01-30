using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest : MonoBehaviour
{
    //지금은 대충 설정해둠
    //나중에 메인제목만 설정해두면 내용이랑 보상은 따로 설정되게 바꾸기
    public string maintitle;
    public string naeyong;
    public string gift;

    public TextMeshProUGUI Tmain;
    public TextMeshProUGUI Tnaeyong;
    public TextMeshProUGUI Tgift;

    private void Awake()
    {
        Tmain.text = maintitle;
        Tnaeyong.text = naeyong;
        Tgift.text = "gift : " + gift;
    }

    public void mainT(string text)
    {
        maintitle = text;
    }
    public void naeT(string text)
    {
        naeyong = text;
    }
    public void giftT(string text)
    {
        gift = text;
    }

}
