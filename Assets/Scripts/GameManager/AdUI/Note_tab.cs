using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Note_tab : MonoBehaviour, IPointerClickHandler
{
    public Note note;
    public int num;
    public GameObject arrow;

    //UI 클릭 이벤트처리
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            note.Set_Note(num);
            arrow.transform.position = new Vector2(this.gameObject.transform.position.x + 2, this.gameObject.transform.position.y);
        }
    }
}
