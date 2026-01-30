using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestButton : MonoBehaviour, IPointerClickHandler
{
    public QuestManager QM;
    public int num;

    //UI 클릭 이벤트처리
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            QM.SwipeQuest(num);
        }
    }
}