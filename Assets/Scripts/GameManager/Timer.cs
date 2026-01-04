using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.EventSystems.EventTrigger;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerUI;
    int count = 0;

    public void S_timer()
    {
        for (int i = 0; i < 10; i++)
        {
            StartCoroutine(StartTimer());
        }
    }

    IEnumerator StartTimer()
    {
        timerUI.text = count.ToString();
        yield return new WaitForSeconds(1f);
        count += 1;
    }
}
