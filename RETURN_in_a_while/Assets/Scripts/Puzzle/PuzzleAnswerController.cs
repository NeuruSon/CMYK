using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAnswerController : MonoBehaviour
{
    public List<GameObject> slots; //유니티 에디터에서 지정하는 옵션 
    List<bool> answers;
    public static int num = 0;

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
            wrong(puzzleNum);
            return false;
        }
        else //다 맞았다면 
        {
            all_cleared(puzzleNum);
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
            wrong(puzzleNum);
            return false;
        }
        else //다 맞았다면 
        {
            all_cleared(puzzleNum);
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
            wrong(puzzleNum);
            return false;
        }
        else //다 맞았다면 
        {
            all_cleared(puzzleNum);
            return true;
        }
    }

    public void resetCheckAnswer(int puzzleName)
    {
        answers = new List<bool>();
    }

    public void all_cleared(int puzzleNum)
    {
        num = puzzleNum + 1;
        PlayData.isPuzzleCleared[puzzleNum] = 1;
        PlayData.toPreScene = true;
        if (PlayData.toPreScene) Debug.Log("true");
    }

    public void wrong(int puzzleNum)
    {
        Debug.Log("wrong!");
    }
}