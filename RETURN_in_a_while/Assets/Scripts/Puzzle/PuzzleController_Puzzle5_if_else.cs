using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController_Puzzle5_if_else : MonoBehaviour
{
    public GameObject tip1, tip2, answer1_1, answer1_2, answer2_1, answer2_2, scale1, scale2, s_bell_r, s_bell_b, off_bell_r, off_bell_b, r_bell_r, r_bell_b, answer_area1, answer_area2;
    GameObject pgCon;

    void Start()
    {
        pgCon = GameObject.Find("PuzzleController");
        pgCon.GetComponent<PuzzleGameController>().onNextBtn();
    }

    public void nextQuestion()
    {
        if (answer_area1.GetComponent<DADSlotController>().isCorrect())
        {
            s_bell_r.SetActive(false);
            r_bell_r.SetActive(true);
        }
        else
        {
            s_bell_r.SetActive(false);
            off_bell_r.SetActive(true);
        }

        tip1.SetActive(false);
        answer1_1.SetActive(false);
        answer2_1.SetActive(false);
        scale1.SetActive(false);
        answer_area1.SetActive(false);

        tip2.SetActive(true);
        answer1_2.SetActive(true);
        answer2_2.SetActive(true);
        scale2.SetActive(true);
        answer_area2.SetActive(true);

        pgCon.GetComponent<PuzzleGameController>().offNextBtn();
    }
}
