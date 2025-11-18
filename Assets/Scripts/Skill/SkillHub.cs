using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public enum SkillList { Skill_1, Skill_2, Skill_3, Skill_4, Skill_5 }



public class SkillHub : MonoBehaviour
{
    public List<GameObject> sList = new List<GameObject>();
    public int a;
    public Transform Content;
    public BattleSystem battleSystem;

    public unit playerUnit;
    public unit enemyUnit;

    private BatteHUD playerHUD;
    private BatteHUD enemyHUD;

    public TextMeshProUGUI dialogueText;

    private bool isDead; // 클래스 멤버 변수

    private List<GameObject> createdSkills = new List<GameObject>();
    private bool isMade = false;

    private void OnEnable()
    {
        CreateSkills();

        foreach (var skill in createdSkills)
            skill.SetActive(true);
    }

    private void OnDisable()
    {
        foreach (var skill in createdSkills)
            skill.SetActive(false);
    }

    private void CreateSkills()
    {
        if (isMade) return;

        for (int i = 0; i < sList.Count; i++)
        {
            GameObject skill = Instantiate(sList[i], Content);
            skill.SetActive(true); // 바로 켜기
            createdSkills.Add(skill); // 리스트에 저장
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
    public void OnSkillClicked(string skillName)
    {
        StartCoroutine(ExecuteSkill(skillName));
        dialogueText.text = "The attack is successful!";
        //battleSystem.startTurnPass(isDead);
        
    }
    private IEnumerator ExecuteSkill(string skillName)
    {
        switch (skillName)
        {
            case "GooBone":
                yield return StartCoroutine(GooBone());
                break;

            case "ShinCham":
                yield return StartCoroutine(ShinCham());
                break;
        }

        // 스킬이 끝난 뒤 BattleSystem에 턴 넘기기
        battleSystem.startTurnPass(isDead);
    }
    private IEnumerator GooBone()
    {
        int damage=10;
        isDead = enemyUnit.TakeDamage(damage);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!";
        yield return new WaitForSeconds(1f);
        

    }

    private IEnumerator ShinCham()
    {
        Debug.Log($"Shhhhhhhhhhhhhhhhhhhhhhhhhhhhi");
        int damage = 15;
        isDead = enemyUnit.TakeDamage(damage);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!";
        yield return new WaitForSeconds(1f);
    }

    public void Back()
    {

        gameObject.SetActive(false);
    }

}
