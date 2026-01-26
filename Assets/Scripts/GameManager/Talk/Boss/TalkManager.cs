using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.IO;

//보스 - 대화 관리스크립트
public class TalkManager : MonoBehaviour
{
    public Unit_State player_state;
    public Unit_State boss_state;
    public Unit_State Talk_ID;
    //int Current_Talk_ID = 1000; //임시로 보스 첫 대화 시작하게 만들어둠

    public TextMeshProUGUI Talk_Text_UI;
    public Image Talk_Icon;

    int talkIndex;
    Dictionary<int, string[]> talkData; //한 캐릭터 대화저장
    Dictionary<int, int> talkData_num; //반복횟수 저장
    Dictionary<int, int[]> talkData_Talking; //연속 대화 저장

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        talkData_num = new Dictionary<int, int>();
        talkData_Talking = new Dictionary<int, int[]>();
        GenerateData();
        
    }

    int current_talk = 10;
    private void Update()
    {
        if(Input.GetMouseButtonUp(0)) //보스 대화만 구현해둠..
        {
            
            if (boss_state.currentHP > 0 && current_talk != 0) //보스 살아있음
            {
                current_talk = 1000;
                Boss_Talk_1(1000);
            }
            else if(boss_state.currentHP <= 0 && current_talk != 0) //보스 죽음
            {
                current_talk = 1100;
                Boss_Talk_2(1100);
            }
            else//기본대사
            {
                //current_talk = 0;
                Print_Talk(0, current_talk);
                
            }
        }
    }
  //대화록 제작하면서 파일 불러오는걸로 저장하는거 수정..
    void GenerateData()
    {
        //id = 0 : 기본대사
        talkData.Add(0, new string[] { "talking" });
        talkData_num.Add(0, 0);

        //id = 1000 : 첫 보스 조우 대사
        talkData_Talking.Add(1000, new int[] { 1000, 2000, 1010, 2010 });
        talkData_num.Add(1000, 0);
        //id = 1000 : 보스 대사 1
        talkData.Add(1000, new string[] { "hi", "new" });
        //id = 1010 : 보스 대사 2
        talkData.Add(1010, new string[] { "what?" });
        //id = 2000 : 플레이어 대사 1
        talkData.Add(2000, new string[] {"???", "..." });
        //id = 2010 : 플레이어 대사 2
        talkData.Add(2010, new string[] { "a", "b", "c" });

        //id = 1100 : 보스 죽음 대사
        talkData_Talking.Add(1100, new int[] { 1100, 2100 });
        talkData_num.Add(1100, 0);
        //id = 1100 : 보스 죽음 대사 1
        talkData.Add(1100, new string[] { "nooo" });
        //id = 2100 : 보스 죽음 플레이어 반응 대사 1
        talkData.Add(2100, new string[] { "yaho!" });

    }

    public string GetTalk(int id, int talkIndex) //Object의 id , string배열의 index
    {
        if (talkIndex == talkData[id].Length) //해당 id를 가지는 string배열의 길이와 같음 
            return null;
        else
            return talkData[id][talkIndex]; //해당 아이디의 해당하는 대사를 반환 
    }

    /*
    void OnMouseUp()
    {
        Print_Talk(1000);
        Debug.Log("mouse up");
    }
    */
    public void Print_Talk(int id, int num) //id와 반복횟수저장소 보내기
    {
        string talkData = GetTalk(id, talkIndex);

        if (talkData == null) //반환된 것이 null이면 더이상 남은 대사가 없음
        {
            talkIndex = 0; //talk인덱스는 다음에 또 사용되므로 초기화해야함
            Debug.Log("talk_end");
            talkData_num[num] += 1;
            //Print_Talk(id, num); 끝나면 다음문장 바로 재생..이 안됨..
            return; //void에서의 return 함수 강제종료 (밑의 코드는 실행되지 않음)
        }

        //다음 문장을 가져오기 위해 talkData의 인덱스를 늘림
        talkIndex++;
        Debug.Log("talk");
        Talk_Text_UI.text = talkData;

        //나중에 이미지도 가져오게 만들어두기
        //지금은 이름 확인해서 색 변경..정도로 구현해봄
        if (id - 2000 < 0) // 보스
        {
            Talk_Icon.color = new Color(255, 0, 0);
        }
        else if(id - 2000 >= 0) // 플레이어
        {
            Talk_Icon.color = new Color(0, 0, 255);
        }

        if (id == 0) //기본대화
            Talk_Icon.color = new Color(0, 0, 0);
    }

    bool Repeat_Text(int id)
    {
        if (talkData_num[id] >= 1) //한번 대화 듣고나면 기본 대화 출력
        {
            return true;
        }
        else
            return false;
    }


    int printID;
    void Boss_Talk_1(int id)
    {
        printID = talkData_Talking[id][talkData_num[id]];
        //Debug.Log(printID);
        //Debug.Log(talkData_num[id]);

        Print_Talk(printID, current_talk);
        
        if (Repeat_Text(current_talk) && talkData_num[id] >= talkData_Talking[id].Length) //이미 들었는지 확인
        {
            current_talk = 0;
            SceneManager.LoadScene("Scenes_Boss");
            return;
        }
    }

    void Boss_Talk_2(int id)
    {
        printID = talkData_Talking[id][talkData_num[id]];

        Print_Talk(printID, current_talk);
        if (Repeat_Text(current_talk) && talkData_num[id] >= talkData_Talking[id].Length) //이미 들었는지 확인
        {
            current_talk = 0;
            SceneManager.LoadScene("Scenes_Adventure");
            return;
        }
    }
}
