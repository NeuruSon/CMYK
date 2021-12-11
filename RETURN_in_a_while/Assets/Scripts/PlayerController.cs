using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DialogueManager DM;
    public static InteractionEvent[] IE;

    void Start()
    {
        IE = FindObjectsOfType<InteractionEvent>();
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
        if (col.gameObject.name == "1to4")
        {
            DM.ShowDialogue(IE[1].GetDialogue());
        }
        if(col.gameObject.name == "13to14")
        {
            DM.ShowDialogue(IE[0].GetDialogue());
        }
    }
}
