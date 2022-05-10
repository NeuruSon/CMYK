using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public static GameObject sCon, gCon, pCon;
    bool isActive = false;
    public bool isAutoPlayable = false;
    public int npcNum; //유니티 에디터에서 지정하는 옵션 
    public GameObject quad; //유니티 에디터에서 지정하는 옵션 
    public string puzzleName = ""; //유니티 에디터에서 지정하는 옵션; 인터렉션했을 때 퍼즐씬에서 오픈할 퍼즐 name 저장 
    public static string npcName;
    InteractionController IC; //함수 써야해서 넣음 
    public static bool inPuzzle = false;

    void Start()
    {
        sCon = GameObject.Find("SceneController");
        gCon = GameObject.Find("GameController");
        pCon = GameObject.Find("Player");
        IC = FindObjectOfType<InteractionController>();
    }

    void Update()
    {
        
        if (isActive == true)
        {
            quad.SetActive(true);
        }
        else if (isActive != true)
        {
            quad.SetActive(false);
        }

        if (isActive == true && isAutoPlayable == true)
        {
            if (PlayData.isPuzzleCleared[npcNum - 1] < 1)
            {
                PlayData.puzzleName = puzzleName; //본 NPC의 puzzle name을, puzzle scene에서 사용하기 위해 임시저장
                pCon.GetComponent<PlayerController>().saveCurrentPosition();
                pCon.GetComponent<PlayerController>().saveCurrentSceneName();
                inPuzzle = true;

                npcName = tag; // npc 이름 넘기기 => findgameobjext
                IC.CheckObject();
            }
            else
            {//클리어 이후의 이벤트 
                
            }
        }
        else if (isActive == true && Input.GetKeyDown(KeyCode.E))
        {
            if (PlayData.isPuzzleCleared[npcNum - 1] < 1)
            {
                PlayData.puzzleName = puzzleName; //본 NPC의 puzzle name을, puzzle scene에서 사용하기 위해 임시저장
                pCon.GetComponent<PlayerController>().saveCurrentPosition();
                pCon.GetComponent<PlayerController>().saveCurrentSceneName();
                inPuzzle = true;
                
                npcName = tag; // npc 이름 넘기기 => findgameobjext
                IC.CheckObject();
            }
            else
            {//클리어 이후의 이벤트 
               
                
            }
            
        }
    }
   

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            isActive = false;
        }
    }
}
