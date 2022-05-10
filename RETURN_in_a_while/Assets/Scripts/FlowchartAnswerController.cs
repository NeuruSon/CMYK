using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowchartAnswerController : MonoBehaviour
{
    public GameObject cleared_tmp; //유니티 에디터에서 지정하는 옵션 
    public List<GameObject> slots; //유니티 에디터에서 지정하는 옵션 
    List<bool> answers;
    bool isCleared = false;

    void Start()
    {
        answers = new List<bool>();
        for (int i = 0; i < slots.Count; ++i)
        {
            answers.Add(slots[i].GetComponent<DADSlotController>().isCorrect());
            //Debug.Log("start_" + i + "_" + answers[i]);
        }
    }

    void Update()
    {
        if (!isCleared && checkAnswer())
        {
            isCleared = true;

            //cleared!!
            Debug.Log("true"); //한번만 떠야 정상
            cleared_tmp.SetActive(true);
        }
    }

    public bool checkAnswer()
    {
        string answer = "";
        for (int i = 0; i < slots.Count; ++i)
        {
            answers[i] = slots[i].GetComponent<DADSlotController>().isCorrect();
            if (answers[i]) answer += "1";
            else answer += "0";
        }
        Debug.Log(answer);

        if (answers.Contains(false)) //오답이 하나라도 있을 경우
        {
            //Debug.Log("wrong!");
            return false;
        }
        else //다 맞았다면 
        {
            return true;
        }
    }
}
