using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintText : MonoBehaviour
{
    public TextMeshProUGUI text;

    /*
    [SerializeField]
    private string name;
    */

    [SerializeField]
    private magic_note note;

    private void Start()
    {
        text.text = note.Sheet1[1].text;
    }
}
