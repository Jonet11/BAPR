using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private void Awake()
    {
        textName.text = itemName;
        textItem.text = quantity.ToString();

        button = GetComponent<Button>();
        itemHub = FindObjectOfType<ItemHub>();
        button.onClick.AddListener(() => { itemHub.OnSkillClicked(this); });
    }
}
