using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public DialogueManager DM;
    public InteractionEvent IE;

    void Start()
    {
      //  DM = FindObjectOfType<DialogueManager>(); // 파일 전체 다 뒤지는거라 성능 떨어지면 수정 
       
    }
   

    // Update is called once per frame
    void Update()
    {
        CheckObject();
    }

    public void CheckObject()
    {

       // 퍼즐씬으로 넘어가기 전 스크립트 출력해야함
        if (NPCController.npcName == "intNPC") // int NPC일때 int 전용대사 출력
        {
            Debug.Log("저는 intNPC입니다 ");
            DM.ShowDialogue(IE.GetDialogue());
        }

    }
    
    
}
