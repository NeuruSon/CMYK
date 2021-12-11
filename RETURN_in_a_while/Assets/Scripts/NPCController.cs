using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public static GameObject sCon, gCon, pCon;
    bool isActive = false;
    public int npcNum; //유니티 에디터에서 지정하는 옵션 
    public GameObject quad; //유니티 에디터에서 지정하는 옵션 
    public string puzzleName = ""; //유니티 에디터에서 지정하는 옵션; 인터렉션했을 때 퍼즐씬에서 오픈할 퍼즐 name 저장 
    public static string npcName;
    InteractionController IC; //함수 써야해서 넣음 
    DialogueManager DM;
    public static bool inPuzzle = false;
    public static bool dontgoPuzzle = false;
    void Awake()
    {
        sCon = GameObject.Find("SceneController");
        gCon = GameObject.Find("GameController");
        pCon = GameObject.Find("Player");
        
    }
    void Start()
    {
        IC = FindObjectOfType<InteractionController>();
        DM = FindObjectOfType<DialogueManager>();
        
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

        if (isActive == true && Input.GetKeyDown(KeyCode.E))
        {
            if (PlayData.isPuzzleCleared[npcNum - 1] < 1)
            {
                PlayData.puzzleName = puzzleName; //본 NPC의 puzzle name을, puzzle scene에서 사용하기 위해 임시저장
                pCon.GetComponent<PlayerController>().saveCurrentPosition();

                
                npcName = tag; // npc 이름 넘기기 => findgameobjext
                IC.CheckObject();
                
               // sCon.GetComponentInChildren<SceneController>().toPuzzleScene();

                
            }
            else
            {//클리어 이후의 이벤트 
                inPuzzle = true;
                dontgoPuzzle = true;
                if(puzzleName == "Puzzle1_int")
                {
                    DM.ShowDialogue(PlayerController.IE[6].GetDialogue());
                }
                if (puzzleName == "Puzzle2_char_string")
                {
                    DM.ShowDialogue(PlayerController.IE[5].GetDialogue());
                }
                if (puzzleName == "Puzzle3_bool")
                {
                    DM.ShowDialogue(PlayerController.IE[2].GetDialogue());
                }
                if (puzzleName == "Puzzle4_array")
                {
                    DM.ShowDialogue(PlayerController.IE[0].GetDialogue());
                }
                
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
