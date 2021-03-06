using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController_Puzzle5_if_else : MonoBehaviour
{
    public GameObject bg_spr1, bg_spr2, answer1_1, answer1_2, answer2_1, answer2_2, r_bell_r, r_bell_b;
    GameObject pgCon, soundBox;

    void Start()
    {
        soundBox = GameObject.Find("soundBox");
        pgCon = GameObject.Find("PuzzleController");
        pgCon.GetComponent<PuzzleGameController>().onNextBtn();
    }

    public void on_if_bell()
    {
        soundBox.GetComponent<GameSubSoundController>().on_effectSFX(); //종소리 
        r_bell_r.SetActive(true);
        r_bell_b.SetActive(false);
    }

    public void on_else_bell()
    {
        soundBox.GetComponent<GameSubSoundController>().on_effectSFX(); //종소리 
        r_bell_r.SetActive(false);
        r_bell_b.SetActive(true);
    }

    public void correct_1()
    {
        r_bell_r.tag = "true";
    }

    public void wrong_1()
    {
        r_bell_r.tag = "false";
    }

    public void correct_2()
    {
        r_bell_b.tag = "true";
    }

    public void wrong_2()
    {
        r_bell_b.tag = "false";
    }

    public void nextQuestion()
    {
        bg_spr1.SetActive(false);
        answer1_1.SetActive(false);
        answer2_1.SetActive(false);

        bg_spr2.SetActive(true);
        answer1_2.SetActive(true);
        answer2_2.SetActive(true);

        r_bell_b.SetActive(false);
        r_bell_r.SetActive(false);

        soundBox.GetComponent<GameSubSoundController>().on_flowchartJINGLE(); //종소리
        pgCon.GetComponent<PuzzleGameController>().offNextBtn();
    }
}
