using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Inventory : MonoBehaviour
{
    public int money = 100;

    string item_name;
    string item_ex;
    int item_num = 0;

    //Dictionary<int, string[]> ItemData; //보유아이템 목록
    public Transform content;
    public TextMeshProUGUI text_money;
    public TextMeshProUGUI text_inventory;
    public GameObject inventory;
    public GameObject Item;

    private void Awake()
    {
        Print_Money();
        //ItemData = new Dictionary<int, string[]>();
    }

    public void Print_Money()
    {
        text_money.text = "money : " + money;
    }
    
    public void Add_Shop_Item(string item_name, string item_ex)
    {
        item_num += 1;
        //ItemData.Add(item_num, new string[] { item_name, item_ex });
        GameObject newItem = Instantiate(Item, content);
        newItem.GetComponent<Item>().SetItem(item_name, item_ex);
        
    }
    public void Print_Inventory()
    {
        inventory.SetActive(true);
    }
    public void Quit_Inventory()
    {
        inventory.SetActive(false);
    }
}
