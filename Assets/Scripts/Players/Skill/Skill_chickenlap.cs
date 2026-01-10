using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill_chickenlap", menuName = "Skills/Skill_chickenlap")]
public class Skill_chickenlap : SkillBase
{
    public int heal = 20;
   
    

    public unit playerUnit;
    
    public override void Execute(GameObject caster)
    {
        Debug.Log("스킬 Execute 실행됨!");

        if (playerUnit == null)
        {

            GameObject Obj = GameObject.FindWithTag("Player");
            Debug.Log("플레이어 찾았아ㅏㅣ!" + Obj.name); // <-- 추가
            playerUnit = Obj.GetComponent<unit>();
        }

        if (hasBeenUsed == false) {
            Debug.Log("heal+ " + heal);
            hasBeenUsed = true;
            playerUnit.TakeDamage(-heal);
        }
        else
        {
            Debug.Log("치킨랩 had been used");
        }
        

    }

}

