using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DialogueManager DM;
    public static InteractionEvent[] IE;
    public InteractionEvent[] showIE; 
    
    
    void Start()
    {
      //  IE = FindObjectsOfType<InteractionEvent>();
        IE = FindObjectsOfType<InteractionEvent>();
        System.Array.Sort<InteractionEvent>(IE, (x, y) => string.Compare(x.name, y.name));
        showIE = IE;
    }

    void Update()
    {
        
    }

    public void saveCurrentPosition()
    {
        PlayData.preSceneLocation = GetComponent<Transform>().transform.localPosition; //현재 플레이어의 위치를, 복귀할 때의 위치 선정을 위해 임시저장
        PlayData.preSceneRotation = GetComponent<Transform>().transform.rotation; //현재 플레이어의 각도를, 복귀할 때의 각도 지정을 위해 임시저장
       // NPCController.inPuzzle = true;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "0")
        {
            NPCController.inPuzzle = true;
            DM.ShowDialogue(IE[0].GetDialogue()); // 한번만 실행되도록 변경하기 
        }
        if(col.gameObject.name == "1")
        {
            NPCController.inPuzzle = true;
            DM.ShowDialogue(IE[1].GetDialogue());
        }
        if(col.gameObject.name == "2")
        {
            NPCController.inPuzzle = true;
            DM.ShowDialogue(IE[2].GetDialogue());
        }
    }
}
