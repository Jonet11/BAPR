using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject Prefabs_Quest;
    public List<GameObject> questList = new List<GameObject>();

    int current_quest_num = 0;

    public void Awake()
    {
        //일단 샘플
        AddQuest();
        FixQuest(0, "Find Apple", "apple", "money + 100");

        AddQuest();
        FixQuest(1, "Help Cat", "meow", "happy + 10");

        AddQuest();
        FixQuest(2, "???", "Talk B", "None");

    }

    public void AddQuest()
    {
        GameObject newquest = Instantiate(Prefabs_Quest, spawnpoint);
        questList.Add(newquest);
        newquest.SetActive(false);
        newquest.transform.position = new Vector2(spawnpoint.position.x - 5, spawnpoint.position.y);
    }
    private void FixQuest(int num, string text1, string text2, string text3)
    {
        questList[num].GetComponent<Quest>().mainT(text1);
        questList[num].GetComponent<Quest>().naeT(text2);
        questList[num].GetComponent<Quest>().giftT(text3);

    }

    private void ShowQuest()
    {
        questList[current_quest_num].SetActive(true);
    }

    private void ExitQuest()
    {
        questList[current_quest_num].SetActive(false);
    }


    public void SwipeQuest(int n) //1은 왼쪽 2는 오른쪽
    {
        ExitQuest();
        if(n == 1)
        {
            if(current_quest_num > 0)
                current_quest_num -= 1;
        }
        else if(n == 2)
        {
            if (current_quest_num < questList.Count -1)
                current_quest_num += 1;
        }
        ShowQuest();
    }

}
