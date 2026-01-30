using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI text;
    public ScrollView shop;
    public TManager TM;

    public GameObject button_shop;
    public GameObject shop_box;
    public GameObject text_box;

    public Inventory Inventory;
    int money;
    public void Enter_shop()
    {
        shop_box.SetActive(true);
        text_box.SetActive(false);
        button_shop.SetActive(false);
        money = Inventory.money;
    }

    public void Quit_shop()
    {
        TM.Print_Talk_UI();
        shop_box.SetActive(false);
    }

    public string item_name;
    public string item_ex;
    public int item_prize;
    public void Buy_shop()
    {
        if (money >= item_prize)
        {
            money -= item_prize;
            Inventory.Add_Shop_Item(item_name, item_ex);
            Inventory.money = money;
            Inventory.Print_Money();
        }
        else
        {
            Debug.Log("no money");
        }
        
    }
}
