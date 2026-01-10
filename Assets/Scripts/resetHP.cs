using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetHP : MonoBehaviour
{
    private static bool isInitialized = false;

    public Unit_State playerhpData;
    public Unit_State bosshpData;

    public void Awake()
    {
        if (isInitialized) return;

        ResetHP();
        isInitialized = true;
    }

    public void ResetHP()
    {
        playerhpData.ResetStats();
        bosshpData.ResetStats();


    }
}
