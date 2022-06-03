using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController_Puzzle6_double_if : MonoBehaviour
{
    public GameObject bell_red, bell_blue, answer_slot_1, answer_slot_2;
    GameObject soundBox;
    bool isRinged_r = false, isRinged_b = false;

    void Start()
    {
        soundBox = GameObject.Find("soundBox");
    }

    void Update()
    {
        if (answer_slot_1.GetComponent<DADSlotController>().isCorrect())
        {
            if (answer_slot_2.transform.childCount != 0)
            {
                if (!answer_slot_2.GetComponent<DADSlotController>().isCorrect() && !isRinged_r)
                {
                    ring('r');
                    bell_red.SetActive(true);
                    bell_blue.SetActive(false);
                }
                if (answer_slot_2.GetComponent<DADSlotController>().isCorrect() && !isRinged_b)
                {
                    ring('b');
                    bell_red.SetActive(false);
                    bell_blue.SetActive(true);
                }
            }
        }
        else
        {
            bell_red.SetActive(false);
            bell_blue.SetActive(false);
        }
    }

    void ring(char c)
    {
        switch (c) {
            case 'r':
                isRinged_b = false;
                isRinged_r = true;
                soundBox.GetComponent<GameSubSoundController>().on_effectSFX(); //종소리
                break;
            case 'b':
                isRinged_b = true;
                isRinged_r = false;
                soundBox.GetComponent<GameSubSoundController>().on_effectSFX(); //종소리
                break;
        }
    }
}
