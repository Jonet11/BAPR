using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    public string unitName;

    public int damage;

    public int maxHP;
    public int currentHP;

    public int waterfall_armor;
    public int high_tide;
    public int administrator;

    public int buff1;
    public int buff2;
    public int buff3;

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
