using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class InteractionController : MonoBehaviour
{
   // DialogueManager DM;
    // public InteractionEvent IE;
    bool ischecking = false;
    public Flowchart puzzleFC;

    void Start()
    {
       // DM = FindObjectOfType<DialogueManager>(); // 파일 전체 다 뒤지는거라 성능 떨어지면 수정 
       
    }
   

    // Update is called once per frame
    void Update()
    {
        if (!ischecking)
        {
            CheckObject();
        }
    }

    public void CheckObject()
    {
        
        ischecking = true;
            
        if (PlayData.isPuzzleCleared[0] == 1) // int, 2-1 if
        {
            
            if(puzzleFC.GetName()=="StartScene")
            {
                puzzleFC.SetIntegerVariable("Puzzle", 5); // 수정해야됨!!!!!!!!! 
            }
            else
            {
                puzzleFC.SetIntegerVariable("Puzzle", 1);
            }

            Debug.Log("int퍼즐 클리어됨");
        }
         
            
        else if (PlayData.isPuzzleCleared[1] == 1) // char 
        {
            puzzleFC.SetIntegerVariable("Puzzle", 2);
            NPCController.inPuzzle = true;
        }

        else if (PlayData.isPuzzleCleared[2] == 1) // bool 
        {
            puzzleFC.SetIntegerVariable("Puzzle", 3);
            NPCController.inPuzzle = true;
        }


        else if (PlayData.isPuzzleCleared[3] == 1) // arr 
        {
            puzzleFC.SetIntegerVariable("Puzzle", 4);
            NPCController.inPuzzle = true;
        }

        else if (PlayData.isPuzzleCleared[4] == 1) // 2-1 if
        {
            puzzleFC.SetIntegerVariable("Puzzle", 5);
           // NPCController.inPuzzle = true;
        }
    }
}
