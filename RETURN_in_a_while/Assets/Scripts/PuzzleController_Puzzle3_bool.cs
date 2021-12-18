using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleController_Puzzle3_bool : MonoBehaviour
{
    public int answerCount = 0; //PuzzleGameContorller에서 접근해 사용 

    public TextMeshProUGUI tQuestionNum, tQuestionContent; //유니티 에디터에서 지정하는 옵션
    public GameObject bExampleL, bExampleR, sExampleL, sExampleR, sAnswer; //유니티 에디터에서 지정하는 옵션 
    TextMeshProUGUI tExampleL, tExampleR; 

    void Start()
    {
        tExampleL = bExampleL.GetComponentInChildren<TextMeshProUGUI>();
        tExampleR = bExampleR.GetComponentInChildren<TextMeshProUGUI>();
        changeQuestion();
    }

    void Update()
    {

    }

    public void changeQuestion()
    {
        resetProperties();

        if (answerCount == 0)
        {
            sAnswer.GetComponent<DADSlotController>().hasSpecificAnswer = true;
            sAnswer.GetComponent<DADSlotController>().answerTag = "bool";
            bExampleL.tag = "bool";
            bExampleR.tag = "string";
            tQuestionNum.text = "Q1.";
            tQuestionContent.text = "Is tomato cabbage?";
            tExampleL.text = "false";
            tExampleR.text = "candy";
        }
        else if (answerCount == 1)
        {
            sAnswer.GetComponent<DADSlotController>().hasSpecificAnswer = true;
            sAnswer.GetComponent<DADSlotController>().answerTag = "bool";
            bExampleL.tag = "string";
            bExampleR.tag = "bool";
            tQuestionNum.text = "Q2.";
            tQuestionContent.text = "Does all apple is black?";
            tExampleL.text = "squid";
            tExampleR.text = "false";
        }
        else if (answerCount == 2)
        {
            sAnswer.GetComponent<DADSlotController>().hasSpecificAnswer = true;
            sAnswer.GetComponent<DADSlotController>().answerTag = "bool";
            bExampleL.tag = "bool";
            bExampleR.tag = "string";
            tQuestionNum.text = "Q3.";
            tQuestionContent.text = "Is ostrich a bird that can't fly?";
            tExampleL.text = "true";
            tExampleR.text = "penguin";
        }
        else if (answerCount == 3)
        {
            sAnswer.GetComponent<DADSlotController>().hasSpecificAnswer = true;
            sAnswer.GetComponent<DADSlotController>().answerTag = "bool";
            sAnswer.GetComponent<DADSlotController>().answerKey = "block_exampleLeft";
            bExampleL.tag = "bool";
            bExampleR.tag = "bool";
            tQuestionNum.text = "Q4.";
            tQuestionContent.text = "Does a worm wriggle when you step on it?";
            tExampleL.text = "true";
            tExampleR.text = "false";
        }
        else
        {
        }
    }

    void resetProperties()
    {
        sAnswer.GetComponent<DADSlotController>().hasSpecificAnswer = false;
        sAnswer.GetComponent<DADSlotController>().answerKey = "";
        sAnswer.GetComponent<DADSlotController>().answerTag = "";
        bExampleL.tag = "block";
        bExampleR.tag = "block";
        bExampleL.GetComponent<DADBlockController>().resetParent();
        bExampleL.GetComponent<DADBlockController>().resetOffset();
        bExampleR.GetComponent<DADBlockController>().resetParent();
        bExampleR.GetComponent<DADBlockController>().resetOffset();
    }
}
