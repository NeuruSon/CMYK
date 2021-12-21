using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    DialogueManager DM;
    // public InteractionEvent IE;
    bool ischecking = false;
    void Start()
    {
      DM = FindObjectOfType<DialogueManager>(); // 파일 전체 다 뒤지는거라 성능 떨어지면 수정 
       
    }
   

    // Update is called once per frame
    void Update()
    {
        if(ischecking==false)
        {
            CheckObject();
        }
       
        
    }

    public void CheckObject()
    {
        
        ischecking = true;
        // 퍼즐씬으로 넘어가기 전 스크립트 출력해야함
        if (NPCController.npcName == "intNPC") // int NPC일때 int 전용대사 출력
        {
            Debug.Log("intNPC");
            
            if (PlayData.isPuzzleCleared[0] == 1)
            {
               DM.ShowDialogue(PlayerController.IE[5].GetDialogue());
                NPCController.inPuzzle = true;
            }
            else
            {
                DM.ShowDialogue(PlayerController.IE[4].GetDialogue());
                NPCController.inPuzzle = false;
            }
           ;
        }
        if(NPCController.npcName == "charNPC")
        {
            Debug.Log("charNPC");
            
            if (PlayData.isPuzzleCleared[1] == 1)
            {
               DM.ShowDialogue(PlayerController.IE[7].GetDialogue());
               NPCController.inPuzzle = true;
            }
            else
            {
                DM.ShowDialogue(PlayerController.IE[6].GetDialogue());
                NPCController.inPuzzle = false;
            }
            
        }
        if (NPCController.npcName == "boolNPC")
        {
            Debug.Log("boolNPC");
            
            if (PlayData.isPuzzleCleared[2] == 1)
            {
                DM.ShowDialogue(PlayerController.IE[9].GetDialogue());
                NPCController.inPuzzle = true;
            }
            else
            {
                DM.ShowDialogue(PlayerController.IE[8].GetDialogue());
                NPCController.inPuzzle = false;
            }
           
        }
        if (NPCController.npcName == "ArrNPC")
        {
            Debug.Log("ArrNPC");
            
            if (PlayData.isPuzzleCleared[3] == 1)
            {
                DM.ShowDialogue(PlayerController.IE[11].GetDialogue());
                NPCController.inPuzzle = true;
            }
            else
            {
                DM.ShowDialogue(PlayerController.IE[10].GetDialogue());
                NPCController.inPuzzle = false;
            }
        }


    }
    public void HideUI()
    {
        DM.go_DialogueBar.SetActive(false);
        DM.go_DialogueNameBar.SetActive(false);
    }

    

}
