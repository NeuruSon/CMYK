using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DialogueManager DM;
    [SerializeField]  public static InteractionEvent[] IE;
    public InteractionEvent[] IEplz;

    
    
    void Start()
    {
        IE = FindObjectsOfType<InteractionEvent>();
        IEplz = IE;
    }

    void Update()
    {
        
    }

    public void saveCurrentPosition()
    {
        PlayData.preSceneLocation = GetComponent<Transform>().transform.localPosition; //현재 플레이어의 위치를, 복귀할 때의 위치 선정을 위해 임시저장
        PlayData.preSceneRotation = GetComponent<Transform>().transform.rotation; //현재 플레이어의 각도를, 복귀할 때의 각도 지정을 위해 임시저장
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Tuto")
        {
            NPCController.inPuzzle = true;
            DM.ShowDialogue(IE[5].GetDialogue()); // 한번만 실행되도록 변경하기 
        }
        if(col.gameObject.name == "VillageEntrance")
        {
            NPCController.inPuzzle = true;
            DM.ShowDialogue(IE[4].GetDialogue());
        }
        if(col.gameObject.name == "ContinueRevival")
        {
            NPCController.inPuzzle = true;
            DM.ShowDialogue(IE[3].GetDialogue());
        }
    }
}
