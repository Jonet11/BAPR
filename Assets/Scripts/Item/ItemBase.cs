using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemBase : MonoBehaviour
{
    public int quantity;
    public string itemName;

    private Button button;
    private ItemHub itemHub;

    public TextMeshProUGUI textName;
    public TextMeshProUGUI textItem;
    //public TextMeshProUGUI textQuantity;

    private void OnEnable()
    {
        textName.text = itemName;
        //textQuantity.text = quantity.ToString();
        textItem.text = quantity.ToString();

        button = GetComponent<Button>();
        itemHub = FindObjectOfType<ItemHub>();
        button.onClick.AddListener(() => { itemHub.OnItemClicked(this.gameObject); });
    }
}
