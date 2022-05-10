﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class InteractionController : MonoBehaviour
{
    bool ischecking = false;
    public Flowchart puzzleFC;
    public int curnum;

    void Start()
    {
        curnum = PuzzleAnswerController.num;
    }
   
    void Update()
    {
        if (!ischecking)
        {
            CheckObject();
        }
        //Debug.Log(curnum);
        //Debug.Log(PuzzleAnswerController.num);
    }

    public void CheckObject()
    {
        
        ischecking = true;
        //puzzleFC.SetIntegerVariable("Puzzle", curnum);

        if(puzzleFC.GetName()=="StartScene")
        {
            puzzleFC.SetIntegerVariable("Puzzle", curnum+4);
        }
        else
        {
            puzzleFC.SetIntegerVariable("Puzzle", curnum);
        }

        //if (PlayData.isPuzzleCleared[0] == 1) // int, 2-1 if
        //{

        //    if(puzzleFC.GetName()=="StartScene")
        //    {
        //        puzzleFC.SetIntegerVariable("Puzzle", 5); // 수정해야됨!!!!!!!!! 
        //    }
        //    else if(puzzleFC.GetName()=="NPC1")
        //    {
        //        puzzleFC.SetIntegerVariable("Puzzle", 1);
        //    }
        //    else
        //    {

        //        Debug.Log("오류");
        //    }

        //}


        //else if (PlayData.isPuzzleCleared[1] == 1) // char 
        //{
        //    puzzleFC.SetIntegerVariable("Puzzle", 2);
        //    NPCController.inPuzzle = true;
        //}

        //else if (PlayData.isPuzzleCleared[2] == 1) // bool 
        //{
        //    puzzleFC.SetIntegerVariable("Puzzle", 3);
        //    NPCController.inPuzzle = true;
        //}


        //else if (PlayData.isPuzzleCleared[3] == 1) // arr 
        //{
        //    puzzleFC.SetIntegerVariable("Puzzle", 4);
        //    NPCController.inPuzzle = true;
        //}

        //else if (PlayData.isPuzzleCleared[4] == 1) // 2-1 if
        //{
        //    puzzleFC.SetIntegerVariable("Puzzle", 5);
        //   // NPCController.inPuzzle = true;
        //}
    }
}
