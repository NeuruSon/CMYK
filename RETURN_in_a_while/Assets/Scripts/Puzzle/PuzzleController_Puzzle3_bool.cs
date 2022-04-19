using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleController_Puzzle3_bool : MonoBehaviour
{
    public int answerCount = 0; //PuzzleGameContorller에서 접근해 사용 

    public TextMeshProUGUI tQuestionNum, tQuestionContent; //유니티 에디터에서 지정하는 옵션
    public GameObject bExampleL, bExampleR, sExampleL, sExampleR, sAnswer, finishBtn; //유니티 에디터에서 지정하는 옵션 
    TextMeshProUGUI tExampleL, tExampleR; 

    void Start()
    {
        tExampleL = bExampleL.GetComponentInChildren<TextMeshProUGUI>();
        tExampleR = bExampleR.GetComponentInChildren<TextMeshProUGUI>();
        finishBtn.SetActive(false);
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
            tQuestionNum.text = "문제1";
            tQuestionContent.text = "토마토는 배추인가요?";
            tExampleL.text = "아니다";
            tExampleR.text = "사탕";
        }
        else if (answerCount == 1)
        {
            sAnswer.GetComponent<DADSlotController>().hasSpecificAnswer = true;
            sAnswer.GetComponent<DADSlotController>().answerTag = "bool";
            bExampleL.tag = "string";
            bExampleR.tag = "bool";
            tQuestionNum.text = "문제2";
            tQuestionContent.text = "모든 사과는 검은색인가요?";
            tExampleL.text = "오징어";
            tExampleR.text = "아니다";
        }
        else if (answerCount == 2)
        {
            sAnswer.GetComponent<DADSlotController>().hasSpecificAnswer = true;
            sAnswer.GetComponent<DADSlotController>().answerTag = "bool";
            bExampleL.tag = "bool";
            bExampleR.tag = "string";
            tQuestionNum.text = "문제3";
            tQuestionContent.text = "타조는 날지 못하는 새인가요?";
            tExampleL.text = "맞다";
            tExampleR.text = "펭귄";
        }
        else if (answerCount == 3)
        {
            finishBtn.SetActive(true);
            sAnswer.GetComponent<DADSlotController>().hasSpecificAnswer = true;
            sAnswer.GetComponent<DADSlotController>().answerTag = "bool";
            sAnswer.GetComponent<DADSlotController>().answerKey = "block_exampleLeft";
            bExampleL.tag = "bool";
            bExampleR.tag = "bool";
            tQuestionNum.text = "문제4";
            tQuestionContent.text = "지렁이도 밟으면 꿈틀하나요?";
            tExampleL.text = "맞다";
            tExampleR.text = "아니다";
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
