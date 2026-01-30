using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{
    public string item_name;
    public string item_ex;

    public TextMeshProUGUI text_ex;

    public void SetItem(string name, string ex)
    {
        item_name = name;
        item_ex = ex;
    }

    private void Awake()
    {
        text_ex.text = "<b>" + item_name + "</b>" + "\n" + "<size=28>" + item_ex + "</size>";
    }

    public void EquipItem()
    {
        Debug.Log("Equip " + item_name);
    }
}
