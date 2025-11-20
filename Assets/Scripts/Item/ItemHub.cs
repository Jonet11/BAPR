using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemHub : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> iList = new List<GameObject>();
    public int a;
    public Transform Content;
    public BattleSystem battleSystem;

    public unit playerUnit;
    public unit enemyUnit;

    private BatteHUD playerHUD;
    private BatteHUD enemyHUD;

    public TextMeshProUGUI dialogueText;

    private bool isDead; // 클래스 멤버 변수

    private List<GameObject> createdItems = new List<GameObject>();
    private bool isMade = false;

    private GameObject selectedItem;

    private void OnEnable()
    {
        CreateItems();

        foreach (var item in createdItems)
        {
            ItemBase baseItem = item.GetComponent<ItemBase>();
            item.SetActive(baseItem.quantity > 0);
        }
    }

    private void OnDisable()
    {
        foreach (var item in createdItems)
            item.SetActive(false);
    }

    private void CreateItems()
    {
        if (isMade) return;

        for (int i = 0; i < iList.Count; i++)
        {
            if (iList[i] != null)
            {
                GameObject item = Instantiate(iList[i], Content);
                ItemBase itemBase = item.GetComponent<ItemBase>();

                // quantity에 따라 on/off
                if (itemBase != null && itemBase.quantity == 0)
                    item.SetActive(false);
                else
                    item.SetActive(true);

                createdItems.Add(item);
            }
        }

        isMade = true;
    }
    public void SetUnits(unit player, unit enemy, BatteHUD pHUD, BatteHUD eHUD)
    {
        playerUnit = player;
        enemyUnit = enemy;
        playerHUD = pHUD;
        enemyHUD = eHUD;

    }
    public void OnItemClicked(GameObject item)
    {
        selectedItem = item;

        ItemBase itemBase = selectedItem.GetComponent<ItemBase>();
        StartCoroutine(UseItem(itemBase));
        dialogueText.text = "Item Used!";
        //battleSystem.startTurnPass(isDead);

    }

    private IEnumerator UseItem(ItemBase item)
    {
        switch (item.itemName)
        {
            case "Healing Potion":
                yield return StartCoroutine(HealingPotion());
                break;

            case "Poison":
                yield return StartCoroutine(Poison());
                break;
            case "Shot Gun":
                yield return StartCoroutine(ShotGun());
                break;
        }

        // 스킬이 끝난 뒤 BattleSystem에 턴 넘기기
        battleSystem.startTurnPass(isDead);
    }

    private IEnumerator HealingPotion()
    {
        int heal = -10;
        isDead = playerUnit.TakeDamage(heal);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "Got Heal!";

        ItemBase itemBase = selectedItem.GetComponent<ItemBase>();
        itemBase.quantity--;

        // 0이 되면 자동 비활성화
        if (itemBase.quantity <= 0)
            selectedItem.SetActive(false);

        yield return new WaitForSeconds(1f);
    }

    private IEnumerator Poison()
    {
        int damage = 10;
        isDead = enemyUnit.TakeDamage(damage);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The Poison Got Kill!!!!";
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator ShotGun()
    {
        int damage = 15;
        isDead = enemyUnit.TakeDamage(damage);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The ShotGun Gos t Kill!!!!";
        yield return new WaitForSeconds(1f);
    }

    public void Back()
    {

        gameObject.SetActive(false);
    }
}
