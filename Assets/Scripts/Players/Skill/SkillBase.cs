using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : ScriptableObject
{
    public string skillName;    // 외부(Manager)에서도 봐야 하니 public
    public float cooldown;   // 자식만 쓰면 되니까 protected
    protected float currentCooldown = 0f;

    public bool keepStateBetweenScenes = false;
    public bool hasBeenUsed = false;

    // 쿨타임 중인지 확인
    public bool IsInCooldown => currentCooldown > 0;

    // 매 프레임 쿨타임을 깎아주는 기능
    public void UpdateCooldown(float deltaTime)
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= deltaTime;
        }
    }

    public void StartCooldown()
    {
        currentCooldown = cooldown;
    }
    public void ResetSkill()
    {
        hasBeenUsed = false;
    }

    public abstract void Execute(GameObject caster); // 이건 자식이 직접 채워야 함
}
