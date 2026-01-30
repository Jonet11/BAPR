using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject NoteBG;
    public GameObject Note_quest;
    public GameObject Note_character;
    public GameObject Note_story;
    public GameObject Note_prop;

    public PlayerActive PA;
    public void Enter_Note()
    {
        NoteBG.SetActive(true);
    }

    public void Quit_Note()
    {
        NoteBG.SetActive(false);
        PA.Actived = false;
    }

    private void Set_Note_F()
    {
        Note_quest.SetActive(false);
        Note_character.SetActive(false);
        Note_story.SetActive(false);
        Note_prop.SetActive(false);
    }

    public void Set_Note(int Note_num)
    {
        switch (Note_num)
        {
            case 1:
                Set_Note_F();
                Note_quest.SetActive(true);

                break;
            case 2:
                Set_Note_F();
                Note_character.SetActive(true);

                break;
            case 3:
                Set_Note_F();
                Note_story.SetActive(true);

                break;
            case 4:
                Set_Note_F();
                Note_prop.SetActive(true);

                break;
        }
    }

}
