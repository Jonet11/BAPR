using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
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

    StatusHub enemyStatus;
    StatusHub playerStatus;

    BossSkill BossSkill;
    BossTalk BossTalk;
    int talk;
    public TextMeshProUGUI Bosslogue;

    public TextMeshProUGUI dialogueText;

    public BatteHUD playerHUD;
    public BatteHUD enemyHUD;

    public GameObject Status_Canvas;
    public GameObject Text_Canvas;
    public GameObject Main_Canvas;

    public SkillHub skillHub;
    public GameObject SHub;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        talk = 0; //대사 순서 확인
        //Status_Canvas.gameObject.SetActive(false);
    }

    /* 마우스 클릭시 상태창 뜨는거.. 아직 미완성
    void MouseClickDown()
    {
        if (state == BattleState.PLAYERTURN && Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Physics2D.Raycast hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if ()
                Status_Canvas.gameObject.SetActive(true);
                Main_Canvas.gameObject.SetActive(false);
                Text_Canvas.gameObject.SetActive(false);
        }
    }
    */

    IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(playerPrefab, playerBS);
        playerUnit = playerGo.GetComponent<unit>();
        playerStatus = playerGo.GetComponent<StatusHub>();

        GameObject enemyGo = Instantiate(enemyPrefab, enemyBS);
        enemyUnit = enemyGo.GetComponent<unit>();
        BossSkill = enemyGo.GetComponent<BossSkill>();
        BossTalk = enemyGo.GetComponent<BossTalk>();
        enemyStatus = enemyGo.GetComponent<StatusHub>();



        dialogueText.text = "The wild " + enemyUnit.unitName + " approaches...";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);


        

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
        talk += 1; //턴 지날때마다 다른 대사 출력
    }
    public void startTurnPass(bool isDead)
    {
        StartCoroutine(turnPass(isDead));
    }
    IEnumerator turnPass( bool isDead)
    {
        SHub.SetActive(false);

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
        string skill_name = BossSkill.Select_Skill();
        dialogueText.text = enemyUnit.unitName + skill_name;


        yield return new WaitForSeconds(2f);

        bool isDead = playerUnit.TakeDamage(BossSkill.Attack_Skill(skill_name));

       playerHUD.SetHP(playerUnit.currentHP);
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

        Debug.Log($"[BattleSystem] Enemy created: {enemyUnit.name}");
        skillHub.SetUnits(playerUnit, enemyUnit, playerHUD, enemyHUD);
        SHub.SetActive(true);
        
        
    }
    //talk 부분에서는 프리팹 보이는거 어떻게 수정할지 미정..
    //뭔가 나중에 배경화면으로 그냥 가리는것도? 괜찮아보임
    public void OnTalkButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        switch (talk)
        {
            case 1:
                StartCoroutine(BossTalk.Talking1());
                break;
            case 2:
                StartCoroutine(BossTalk.Talking2());
                break;
            default:
                StartCoroutine(BossTalk.Talking0());
                break;
        }

    }
    //상태이상 확인 버튼
    public void OnStatus1Button()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        Status_Canvas.gameObject.SetActive(true);
        Main_Canvas.gameObject.SetActive(false);
        playerBS.GetChild(0).gameObject.SetActive(false);
        enemyBS.GetChild(0).gameObject.SetActive(false);
        enemyStatus.Boss(enemyUnit);
    }
    public void OnStatus2Button()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        Status_Canvas.gameObject.SetActive(true);
        Main_Canvas.gameObject.SetActive(false);
        playerStatus.Player(playerUnit);
        playerBS.GetChild(0).gameObject.SetActive(false); //프리팹 안보이게
        enemyBS.GetChild(0).gameObject.SetActive(false);
    }
    //스테이터스 테스트용
    public void OnStatusPlusButton()
    {
        enemyUnit.administrator += 1;
        playerUnit.buff1 += 1;
        playerUnit.buff2 += 2;
    }

    public void OnExitButton()
    {
        Status_Canvas.gameObject.SetActive(false);
        Main_Canvas.gameObject.SetActive(true);
        Text_Canvas.gameObject.SetActive(false);
        playerBS.GetChild(0).gameObject.SetActive(true);
        enemyBS.GetChild(0).gameObject.SetActive(true);
    }
}



