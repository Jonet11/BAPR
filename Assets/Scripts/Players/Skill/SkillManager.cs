using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // 이 코드가 있어야 인스펙터 창에서 리스트 내용이 보입니다.
public class SkillSlot
{
    public KeyCode key;       // 이 스킬을 발동할 키 (Q, W, E, R 등)
    public SkillBase skill;   // 연결할 스킬 스크립트
}
public class SkillManager : MonoBehaviour
{
    public List<SkillSlot> skillSlots = new List<SkillSlot>();

    void Awake()
    {
        // 1. 모든 스킬을 '나만의 복사본'으로 만듭니다.
        foreach (var slot in skillSlots)
        {
            if (slot.skill != null)
            {
                // 씬 이동 시 유지를 원하지 않는 스킬만 복사본(Instantiate)을 만듭니다.
                if (slot.skill.keepStateBetweenScenes == false)
                {
                    slot.skill = Instantiate(slot.skill);
                    Debug.Log($"{slot.skill.skillName}은 복사본을 생성했습니다. (씬 이동 시 초기화됨)");
                }
                else
                {
                    Debug.Log($"{slot.skill.skillName}은 원본을 사용합니다. (씬 이동 시 유지됨)");
                }
            }
        }
    }

    void Update()
    {
        foreach (var slot in skillSlots)
        {
            if (slot.skill == null) continue;

            // 2. 쿨타임 실시간 계산 (각 스킬 복사본의 시간을 깎음)
            slot.skill.UpdateCooldown(Time.deltaTime);

            // 3. 입력 체크
            if (Input.GetKeyDown(slot.key))
            {
                Debug.Log($"{slot.key} 키가 눌렸습니다!"); // <-- 추가
                TryActivateSkill(slot.skill);
            }
        }
    }

    void TryActivateSkill(SkillBase skill)
    {
        if (skill.IsInCooldown)
        {
            Debug.Log($"{skill.skillName}은 아직 쿨타임 중입니다!");
            return;
        }

        // 실행!
        skill.Execute(this.gameObject);
        // 쿨타임 시작!
        skill.StartCooldown();
    }

}
