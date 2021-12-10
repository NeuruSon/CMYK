﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
  //  public int lineY; // 엑셀 줄 개수
   // public int s_lineY;

    [SerializeField] DialogueEvent dialogue;


    public Dialogue[] GetDialogue()
    {
       dialogue.dialogues = DatabaseManager.instance.GetDialogue((int)dialogue.line.x, (int)dialogue.line.y);
        return dialogue.dialogues;
    }


}