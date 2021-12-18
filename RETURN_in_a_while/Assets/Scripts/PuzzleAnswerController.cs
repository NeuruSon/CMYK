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
        for (int i = 0; i < slots.Count; ++i)
        {
            answers.Add(slots[i].GetComponent<DADSlotController>().isCorrect());
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
            return true;
        }
    }
}