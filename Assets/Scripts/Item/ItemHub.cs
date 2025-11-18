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

    private void OnEnable()
    {
        CreateItems();

        foreach (var item in createdItems)
            item.SetActive(true);
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
                // 프리팹에서 ItemBase 컴포넌트 가져오기
                ItemBase itemBase = iList[i].GetComponent<ItemBase>();

                // 아이템이 있고, quantity가 0이면 생성 안 함
                if (itemBase != null && itemBase.quantity == 0)
                {
                    continue; // 이 아이템은 스킵
                }

                // quantity > 0 일 때만 생성
                GameObject item = Instantiate(iList[i], Content);
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
    public void OnSkillClicked(ItemBase item)
    {
        StartCoroutine(UseItem(item));
        dialogueText.text = "The attack is successful!";
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
