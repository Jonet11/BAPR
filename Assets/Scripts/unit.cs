using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    public string unitName;

    public int damage;

    public int maxHP;
    public int currentHP;

    //상태이상 올페 보스
    public int administrator = 0; //관리자
    public int high_tide = 0; //만조
    public int waterfall_armor = 0; //폭포갑주

    //상태이상 플레이어
    public int buff1 = 0;
    public int buff2 = 0;
    public int buff3 = 0;

    public bool TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            return true;
        }
        else {return false; }
    }
}
