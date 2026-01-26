using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TManager : MonoBehaviour
{
    public TextMeshProUGUI Talk_Text_UI;
    public GameObject Text;
    public GameObject button_shop;

    Dictionary<int, string[]> talkData; //한 캐릭터 대화저장
    Dictionary<int, int> talkData_num; //반복횟수 저장

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        talkData_num = new Dictionary<int, int>();
        GenerateData();
    }

    void GenerateData()
    {
        //id = 0 : 기본대사
        talkData.Add(0, new string[] { "talking" });
        talkData_num.Add(0, 0);

        //id = 100 : npc 대화 1
        talkData.Add(100, new string[] { "hello" });
        talkData_num.Add(100, 0);

        //id = 200 : npc 대화 2
        talkData.Add(200, new string[] { "Do you want shop?" });
        talkData_num.Add(200, 0);
    }


    int talkIndex;
    public int ID = 0;
    public string GetTalk(int id, int talkIndex) //Object의 id , string배열의 index
    {
        if (talkIndex == talkData[id].Length) //해당 id를 가지는 string배열의 길이와 같음 
            return null;
        else
            return talkData[id][talkIndex]; //해당 아이디의 해당하는 대사를 반환 
    }

    public void Print_Talk(int id, int num) //id와 반복횟수저장소 보내기
    {
        if (ID == id) //지금 출력중인 텍스트가 맞다면 그대로 출력
        {
            Text.SetActive(true);
            string talkData = GetTalk(id, talkIndex);

            if (talkData == null) //반환된 것이 null이면 더이상 남은 대사가 없음
            {
                talkIndex = 0; //talk인덱스는 다음에 또 사용되므로 초기화해야함
                Debug.Log("talk_end");
                talkData_num[num] += 1;
                Text.SetActive(false);
                button_shop.SetActive(false);
                ID = 0; //대화중복 방지
                return;
            }

            //다음 문장을 가져오기 위해 talkData의 인덱스를 늘림
            talkIndex++;
            Debug.Log("talk");
            Talk_Text_UI.text = talkData;

            if (id == 200) //상점인경우 버튼 활성화
                button_shop.SetActive(true);
        }
    }

    public void Print_Talk_UI()
    {
        Print_Talk(ID, ID);
    }
}
