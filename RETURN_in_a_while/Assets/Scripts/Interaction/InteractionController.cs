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
            DM.ShowDialogue(PlayerController.IE[6].GetDialogue());
            
            // 다시 말걸떈 count 변수 달아서 마지막 문장만 출력하도록 변경 

        }
        if(NPCController.npcName == "charNPC")
        {
            Debug.Log("charNPC");
            DM.ShowDialogue(PlayerController.IE[2].GetDialogue());
            NPCController.inPuzzle = false;
        }
        if (NPCController.npcName == "boolNPC")
        {
            Debug.Log("boolNPC");
            DM.ShowDialogue(PlayerController.IE[1].GetDialogue());
            NPCController.inPuzzle = false;
        }
        if (NPCController.npcName == "ArrNPC")
        {
            Debug.Log("ArrNPC");
            DM.ShowDialogue(PlayerController.IE[0].GetDialogue());
            NPCController.inPuzzle = false;
        }


    }
    public void HideUI()
    {
        DM.go_DialogueBar.SetActive(false);
        DM.go_DialogueNameBar.SetActive(false);
    }

    

}
