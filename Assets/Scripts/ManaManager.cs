using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public static ManaManager Instance;

    public int energy = 0;
    public int maxEnergy = 30;
    public float regenInterval = 1f;
    public TextMeshProUGUI manaHud;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            manaHud.text = energy.ToString();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(RegenEnergy());
    }
    private void Update()
    {
        manaHud.text = energy.ToString();
    }

    IEnumerator RegenEnergy()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(regenInterval);

            if (energy < maxEnergy)
                energy++;
            
        }
    }

    public bool UseEnergy(int amount)
    {
        if (energy < amount)
            return false;

        energy -= amount;
        return true;
    }
}
