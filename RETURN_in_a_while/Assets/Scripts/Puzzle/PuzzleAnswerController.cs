using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAnswerController : MonoBehaviour
{
    public List<GameObject> slots; //유니티 에디터에서 지정하는 옵션 
    List<bool> answers;

    void Awake()
    {
        answers = new List<bool> ();
    }

    void Update()
    {

    }

    public bool checkAnswer(int puzzleNum)
    {
        string answer = "";
        for (int i = 0; i < slots.Count; ++i)
        {
            answers.Add(slots[i].GetComponent<DADSlotController>().isCorrect());

            answer += slots[i].GetComponent<DADSlotController>().isCorrect();
        }

        Debug.Log(answer);

        if (answers.Contains(false)) //오답이 하나라도 있을 경우
        {
            PlayData.isPuzzleCleared[puzzleNum] -= 1;
            Debug.Log("wrong!");
            return false;
        }
        else //다 맞았다면 
        {
            PlayData.isPuzzleCleared[puzzleNum] = 1;
            PlayData.toPreScene = true;
            return true;
        }
    }

    public bool checkAnswer_tag(int puzzleNum)
    {
        for (int i = 0; i < slots.Count; ++i)
        {
            answers.Add((slots[i].tag == "answer") || (slots[i].tag == "true") ? true : false);
        }

        if (answers.Contains(false)) //오답이 하나라도 있을 경우 
        {
            PlayData.isPuzzleCleared[puzzleNum] -= 1;
            Debug.Log("wrong!");
            return false;
        }
        else //다 맞았다면 
        {
            PlayData.isPuzzleCleared[puzzleNum] = 1;
            PlayData.toPreScene = true;
            return true;
        }
    }

    public bool checkAnswer_bool(int puzzleNum)
    {
        for (int i = 0; i < slots.Count; ++i)
        {
            answers.Add(slots[i]);
        }

        if (answers.Contains(false)) //오답이 하나라도 있을 경우 
        {
            PlayData.isPuzzleCleared[puzzleNum] -= 1;
            Debug.Log("wrong!");
            return false;
        }
        else //다 맞았다면 
        {
            PlayData.isPuzzleCleared[puzzleNum] = 1;
            PlayData.toPreScene = true;
            return true;
        }
    }
}