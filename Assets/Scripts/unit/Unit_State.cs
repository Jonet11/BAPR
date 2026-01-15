using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewPlayerStats", menuName = "Stats/Unit_State")]
public class Unit_State : ScriptableObject
{
    public int maxHP = 100;
    public int currentHP = 100;
    public int ID = 0;

    public void ResetStats()
    {
        currentHP = maxHP;
    }
}
