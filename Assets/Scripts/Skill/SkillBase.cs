using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillBase : MonoBehaviour
{

    public int mana;
    public string skillName;

    private Button button; 
    private SkillHub skillHub;

    public TextMeshProUGUI textName;
    public TextMeshProUGUI textMana;

    private void Awake()
    {
        textName.text = skillName;
        textMana.text = mana.ToString();

        button = GetComponent<Button>(); 
        skillHub = FindObjectOfType<SkillHub>();
        button.onClick.AddListener(() => { skillHub.OnSkillClicked(skillName); });
    }

}
