using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleGameController : MonoBehaviour
{
    //퍼즐 모드일 때의 게임 컨트롤러입니다.
    GameObject sCon;
    public GameObject puzzles, nextBtn, doneBtn; //유니티 에디터에서 지정하는 옵션 
    Dictionary<string, GameObject> puzzleCanvases;
    GameObject currentPuzzleCanvas;

    void Awake()
    {
        puzzleCanvases = new Dictionary<string, GameObject>();
    }

    void Start()
    {
        sCon = GameObject.Find("SceneController");
        //puzzles 뭉탱이에 들어있는 퍼즐 개체를 dictionary에 담음 
        for (int i = 0; i < puzzles.transform.childCount; ++i)
        {
            puzzleCanvases.Add(puzzles.gameObject.transform.GetChild(i).gameObject.name, puzzles.gameObject.transform.GetChild(i).gameObject);
        }
        //받아온 puzzle name을 이용해 해당 puzzle canvas를 활성화
        currentPuzzleCanvas = puzzleCanvases[PlayData.puzzleName]; 
        currentPuzzleCanvas.SetActive(true);
    }

    void Update()
    {
        
    }

    public void checkAnswer()
    {
        //dictionary에서 key를 이용해 value의 index를 반환하고, 해당 값을 npcNum 대신 보내줌
        if (currentPuzzleCanvas.GetComponent<PuzzleAnswerController>().checkAnswer(puzzleCanvases.Keys.ToList().IndexOf(PlayData.puzzleName)))
        {
            if (PlayData.currentChapterNum == 2)
            {
                sCon.GetComponent<SceneController>().toShowPuzzleScene();
            }
            sCon.GetComponent<SceneController>().toTempMapScene();
        }
        else
        {
            if (PlayData.currentChapterNum <= 1)
            {
                sCon.GetComponent<SceneController>().toPuzzleYScene();
            }
            else if (PlayData.currentChapterNum == 2)
            {
                sCon.GetComponent<SceneController>().toPuzzleCScene();
            }
            else if (PlayData.currentChapterNum == 3)
            {
                sCon.GetComponent<SceneController>().toPuzzleMScene();
            }
            else if (PlayData.currentChapterNum == 4)
            {
                sCon.GetComponent<SceneController>().toPuzzleKScene();
            }
            else
            {
                Debug.Log("OutOfIndexError");
                //sCon.GetComponent<SceneController>().toPuzzleScene();
            }
        }
    }

    public void checkAnswer_tag()
    {
        //dictionary에서 key를 이용해 value의 index를 반환하고, 해당 값을 npcNum 대신 보내줌
        if (currentPuzzleCanvas.GetComponent<PuzzleAnswerController>().checkAnswer_tag(puzzleCanvases.Keys.ToList().IndexOf(PlayData.puzzleName)))
        {
            if (PlayData.currentChapterNum == 2)
            {
                sCon.GetComponent<SceneController>().toShowPuzzleScene();
            }
            sCon.GetComponent<SceneController>().toTempMapScene();
        }
        else
        {
            if (PlayData.currentChapterNum <= 1)
            {
                sCon.GetComponent<SceneController>().toPuzzleYScene();
            }
            else if (PlayData.currentChapterNum == 2)
            {
                sCon.GetComponent<SceneController>().toPuzzleCScene();
            }
            else if (PlayData.currentChapterNum == 3)
            {
                sCon.GetComponent<SceneController>().toPuzzleMScene();
            }
            else if (PlayData.currentChapterNum == 4)
            {
                sCon.GetComponent<SceneController>().toPuzzleKScene();
            }
            else
            {
                Debug.Log("OutOfIndexError");
                //sCon.GetComponent<SceneController>().toPuzzleScene();
            }
        }
    }

    public void quitPuzzle()
    {
        //오답 처리를 하고 씬 전환 
        PlayData.isPuzzleCleared[puzzleCanvases.Keys.ToList().IndexOf(PlayData.puzzleName)] -= 1; 
        sCon.GetComponent<SceneController>().toTempMapScene();
    }

    public void nextPuzzle()
    {
        if (currentPuzzleCanvas.name == "Puzzle3_bool")
        {
            if (currentPuzzleCanvas.GetComponent<PuzzleAnswerController>().checkAnswer(puzzleCanvases.Keys.ToList().IndexOf(PlayData.puzzleName)))
            {
                currentPuzzleCanvas.GetComponent<PuzzleController_Puzzle3_bool>().answerCount += 1;
                currentPuzzleCanvas.GetComponent<PuzzleController_Puzzle3_bool>().changeQuestion();
                if (currentPuzzleCanvas.GetComponent<PuzzleController_Puzzle3_bool>().answerCount == 3)
                {
                    GameObject.Find("NextBtn").SetActive(false);
                }
            }
            else
            {
                sCon.GetComponent<SceneController>().toPuzzleYScene();
            }
        }
    }

    public void onNextBtn()
    {
        nextBtn.SetActive(true);
        doneBtn.SetActive(false);
    }

    public void offNextBtn()
    {
        nextBtn.SetActive(false);
        doneBtn.SetActive(true);
    }
}
