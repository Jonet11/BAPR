using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    public GameObject enermyPrefab;
    unit boss;

    int skill;
    string skill_name;
    int damage;
    // Start is called before the first frame update
    void Awake()
    {
        //GameObject enermyGo = GameObject.Find("enermyPrefab");
        //boss = enermyGo.GetComponent<unit>();
    }
    public string Select_Skill()
    {
        skill = Random.Range(1, 4);

        switch (skill)
        {
            case 1:
                skill_name = " skill num1";
                break;
            case 2:
                skill_name = " skill num2";
                break;
            case 3:
                skill_name = " skill num3";
                break;
        }

        return skill_name;
    }

    public int Attack_Skill(string name)
    {

        if(name == " skill num1")
        {
            damage = 10;
        }
        else if(name == " skill num2")
        {
            damage = 20;
        }
        else if(name == " skill num3")
        {
            damage = 30;
        }

        return damage;
    }

    // Update is called once per frame
    public void Skill1()
    {

    }
}
