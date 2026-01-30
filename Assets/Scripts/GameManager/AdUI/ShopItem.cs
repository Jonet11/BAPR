using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    string item_name;
    string item_ex;
    public int item_prize;

    public TextMeshProUGUI text_ex;
    public TextMeshProUGUI text_prize;
    public Image item_icon;

    public Shop shop;
    public Item item;

    private void Awake()
    {
        item_name = item.item_name;
        item_ex = item.item_ex;
        shop = GameObject.Find("GameManager").GetComponent <Shop>();
        text_ex.text = "<b>"+item_name + "</b>" + "\n" + "<size=28>" + item_ex + "</size>";
        text_prize.text = item_prize.ToString();
    }

    public void GetItem()
    {
        shop.item_name = item_name;
        shop.item_ex = item_ex;
        shop.item_prize = item_prize;
        shop.Buy_shop();
    }
}
