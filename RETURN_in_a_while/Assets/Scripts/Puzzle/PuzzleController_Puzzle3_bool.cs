using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleController_Puzzle3_bool : MonoBehaviour
{
    public int answerCount = 0; //PuzzleGameContorller에서 접근해 사용 

    GameObject mainSoundBox, soundBox, pCon;
    public TextMeshProUGUI tQuestionContent; //유니티 에디터에서 지정하는 옵션
    public GameObject bExampleL, bExampleR, sExampleL, sExampleR, sAnswer, finishBtn, effect_bg, fail_spr; //유니티 에디터에서 지정하는 옵션 
    TextMeshProUGUI tExampleL, tExampleR;

    void Start()
    {
        pCon = GameObject.Find("PuzzleController");
        mainSoundBox = GameObject.Find("mainSoundBox");
        soundBox = GameObject.Find("soundBox");
        tExampleL = bExampleL.GetComponentInChildren<TextMeshProUGUI>();
        tExampleR = bExampleR.GetComponentInChildren<TextMeshProUGUI>();
        finishBtn.SetActive(false);
        answerCount = PlayData.p3;
        changeQuestion();
    }

    void Update()
    {
        answerCount = PlayData.p3;
    }

    public void changeQuestion()
    {
        resetProperties();

        if (answerCount == 0)
        {
            bExampleL.tag = "bool";
            bExampleR.tag = "string";
            tQuestionContent.text = "Q1. 토마토는 배추인가요?";
            tExampleL.text = "아니다";
            tExampleR.text = "사탕";
        }
        else if (answerCount == 1)
        {
            bExampleL.tag = "string";
            bExampleR.tag = "bool";
            tQuestionContent.text = "Q2. 모든 사과는 검은색인가요?";
            tExampleL.text = "오징어";
            tExampleR.text = "아니다";
        }
        else if (answerCount == 2)
        {
            bExampleL.tag = "bool";
            bExampleR.tag = "string";
            tQuestionContent.text = "Q3. 타조는 날지 못하는 새인가요?";
            tExampleL.text = "맞다";
            tExampleR.text = "펭귄";
        }
        else if (answerCount == 3)
        {
            finishBtn.SetActive(true);
            sAnswer.GetComponent<DADSlotController>().useKey = true;
            sAnswer.GetComponent<DADSlotController>().answerKey = "block_exampleLeft";
            bExampleL.tag = "bool";
            bExampleR.tag = "bool";
            tQuestionContent.text = "Q4. 지렁이도 밟으면 꿈틀하나요?";
            tExampleL.text = "맞다";
            tExampleR.text = "아니다";
        }
        else
        {
        }
    }

    void resetProperties()
    {
        sAnswer.GetComponent<DADSlotController>().child = null;
        bExampleL.tag = "block";
        bExampleR.tag = "block";
        bExampleL.GetComponent<DADBlockController>().resetParent();
        bExampleL.GetComponent<DADBlockController>().resetOffset();
        bExampleR.GetComponent<DADBlockController>().resetParent();
        bExampleR.GetComponent<DADBlockController>().resetOffset();
    }

    public void nextPuzzle()
    {
        Debug.Log(answerCount);
        if (gameObject.GetComponent<PuzzleAnswerController>().checkAnswer(2))
        {
            PlayData.p3 += 1;
            answerCount = PlayData.p3;
            soundBox.GetComponent<GameSoundController>().on_flowchartJINGLE(); //정답 징글로 일시 대체 
            changeQuestion();

            if (answerCount == 3)
            {
                GameObject.Find("NextBtn").SetActive(false);
            }
        }
        else
        {
            pCon.GetComponent<PuzzleGameController>().result_failed();
        }
    }

    public void resetPuzzle()
    {
        PlayData.p3 = 0;
    }
}