using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetSkill : MonoBehaviour
{
    public List<SkillBase> skillsToReset = new List<SkillBase>();

    // static 변수는 게임이 꺼지기 전까지 메모리에 유지됩니다.
    private static bool isInitialized = false;

    void Awake()
    {
        // 이미 초기화된 적이 있다면 실행하지 않고 나갑니다.
        if (isInitialized) return;

        ResetAllSkills();

        // 초기화 완료 표시
        isInitialized = true;

        // 만약 이 매니저가 씬 이동 시에도 파괴되지 않길 원한다면 추가
        // DontDestroyOnLoad(gameObject); 
    }

    public void ResetAllSkills()
    {
        foreach (SkillBase skill in skillsToReset)
        {
            if (skill != null) skill.ResetSkill();
        }
        Debug.Log("게임 시작 후 최초 1회 스킬 전체 리셋 완료");
    }
}
