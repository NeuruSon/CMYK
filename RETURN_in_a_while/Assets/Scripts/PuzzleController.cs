using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    GameObject UI;
    GameObject sCon; //SceneController
    GameObject slot;

    bool[] answers = new bool[1];

    void Awake()
    {
        sCon = GameObject.Find("SceneController");
        slot = GameObject.Find("slot1");
    }

    void Update()
    {

    }

    public void checkAnswer()
    {
        answers[0] = slot.GetComponent<DADSlotController>().isCorrect();

        if (answers[0] == true)
        {
            sCon.GetComponent<SceneController>().toTestScene();
        }
        else
        {
            sCon.GetComponent<SceneController>().toPuzzleScene();
        }
    }
}