﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAnswerController : MonoBehaviour
{
    GameObject sCon; //SceneController
    public List<GameObject> slots; //유니티 에디터에서 지정하는 옵션 
    List<bool> answers;

    void Awake()
    {
        sCon = GameObject.Find("SceneController");
        answers = new List<bool> ();

    }

    void Update()
    {

    }

    public void checkAnswer()
    {
        for (int i = 0; i < slots.Count; ++i)
        {
            answers.Add(slots[i].GetComponent<DADSlotController>().isCorrect());
        }

        if (answers.Contains(false)) //오답이 하나라도 있을 경우 
        {
            sCon.GetComponent<SceneController>().toPuzzleScene();
        }
        else //다 맞았다면 
        {
            sCon.GetComponent<SceneController>().toTempMapScene();
        }
    }
}