using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//일반맵에서 npc 눌렀을때 텍스트 보내기
public class TalkText : MonoBehaviour
{
    public TManager TM;
    public int ID = 0;
    public PlayerActive PA;

    public int GetID()
    {
        return ID;
    }

    //오브젝트 클릭 이벤트 처리(콜라이더 필수)
    private void OnMouseDown()
    {
        if (!PA.Actived)
        {
            if (TM.ID == 0) //대화 여러개 중복 방지
                TM.ID = GetID();
            TM.Print_Talk(ID, ID);
        }
    }

}
