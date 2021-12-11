using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DialogueManager DM;

    public InteractionEvent IE;
    void Start()
    {
        
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
            DM.ShowDialogue(IE.GetDialogue());
        }

    }
}
