using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActive : MonoBehaviour
{
    public Note note;
    public bool Actived = false;

    public Inventory inventory;

    // Update is called once per frame
    void Update()
    {   
        //노트
        if (Input.GetKeyDown(KeyCode.Q) && !Actived)
        {
            note.Enter_Note();
            Actived = true;
        }
        else if(Input.GetKeyDown(KeyCode.Q) && Actived)
        {
            note.Quit_Note();
        }

        //인벤토리
        if (Input.GetKeyDown(KeyCode.I) && !Actived)
        {
            inventory.Print_Inventory();
            Actived = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && Actived)
        {
            inventory.Quit_Inventory();
            Actived = false;
        }
    }
}
