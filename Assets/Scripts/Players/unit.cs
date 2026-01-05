using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;



public class unit : MonoBehaviour
{
    public Unit_State hpData;

    public static unit Instance;

    public int MaxHp;
    public int currentHp;

    public Slider Slider;

    

    private void Start()
    {
        setSlider();
        // Player의 Start() 등에 추가
        
        // 게임 시작 시 혹은 씬 시작 시 필요에 따라 호출
        if(hpData.kicker != 0)
        {
            hpData.ResetStats();
            hpData.kicker = 0;
        }
    }


    private void Update()
    {
        Slider.value = hpData.currentHP;
            }

    public bool TakeDamage(int damage)
    {
        hpData.currentHP -= damage;
        Debug.Log($"현재 체력: {hpData.currentHP} / {hpData.maxHP}");
        if (currentHp < 0)
        {
            return true;
        }
        else { return false; }
    }

    void setSlider()
    {
        Slider.maxValue = MaxHp;
        Slider.value = currentHp;
    }
}
