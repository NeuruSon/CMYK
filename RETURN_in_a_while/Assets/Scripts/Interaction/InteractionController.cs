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
    public int curnum;

    void Start()
    {
        // DM = FindObjectOfType<DialogueManager>(); // 파일 전체 다 뒤지는거라 성능 떨어지면 수정 
        curnum = PuzzleAnswerController.num;
    }
   

    // Update is called once per frame
    void Update()
    {
        if(ischecking==false)
        {
            CheckObject();
        }
        //Debug.Log(curnum);
        //Debug.Log(PuzzleAnswerController.num);
    }

    public void CheckObject()
    {
        ischecking = true;
       
        if(puzzleFC.GetName()=="StartScene")
        {
            puzzleFC.SetIntegerVariable("Puzzle", curnum+4);
        }
        else if(puzzleFC.GetName()=="Tr1")
        {
            puzzleFC.SetIntegerVariable("Puzzle", curnum + 6);
        }
        else 
        {
            Debug.Log("인식");
            puzzleFC.SetIntegerVariable("Puzzle", curnum);
        }
            
        
    }
}
