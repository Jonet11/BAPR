using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN,  ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBS;
    public Transform enemyBS;

    unit playerUnit;
    unit enemyUnit;

    BossSkill Boss;

    public TextMeshProUGUI dialogueText;

    public BatteHUD platerHUD;
    public BatteHUD enemyHUD;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(playerPrefab, playerBS);
        playerUnit = playerGo.GetComponent<unit>();

        GameObject enemyGo = Instantiate(enemyPrefab, enemyBS);
        enemyUnit = enemyGo.GetComponent<unit>();
        Boss = enemyGo.GetComponent<BossSkill>();

        dialogueText.text = "The wild " + enemyUnit.unitName + " approaches...";

        platerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {

        dialogueText.text = "Choose an action:";
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBettle();
        }
        else { state = BattleState.ENEMYTURN;

            StartCoroutine(EnermyTurn());
        }

    }

    void EndBettle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "You Won The Battle!";
        }
        else
        {
            dialogueText.text = "You sucks!";
        }
    }

    IEnumerator EnermyTurn()
    {
        string skill_name = Boss.Select_Skill();
        dialogueText.text = enemyUnit.unitName + skill_name;


        yield return new WaitForSeconds(2f);

        bool isDead = playerUnit.TakeDamage(Boss.Attack_Skill(skill_name));

       platerHUD.SetHP(playerUnit.currentHP);
        if (isDead)
        {
            state = BattleState.LOST;
            EndBettle();
        }
        else
        {
            state =BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack());
    }
}

