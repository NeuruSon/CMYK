﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController_Puzzle6_double_if : MonoBehaviour
{
    public GameObject bell_red, bell_blue, answer_slot_1, answer_slot_2;

    void Update()
    {
        if (answer_slot_1.GetComponent<DADSlotController>().isCorrect())
        {
            if (answer_slot_2.transform.childCount != 0)
            {
                if (!answer_slot_2.GetComponent<DADSlotController>().isCorrect())
                {
                    bell_red.SetActive(true);
                    bell_blue.SetActive(false);
                }
                if (answer_slot_2.GetComponent<DADSlotController>().isCorrect())
                {
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
}
