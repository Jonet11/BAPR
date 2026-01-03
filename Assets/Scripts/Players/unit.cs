using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unit : MonoBehaviour
{
    public int MaxHp;
    public int currentHp;

    public Slider Slider;

    private void Start()
    {
        setSlider();    
    }

    private void Update()
    {
        Slider.value = currentHp;
    }

    public bool TakeDamage(int damage)
    {
        currentHp -= damage;
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
