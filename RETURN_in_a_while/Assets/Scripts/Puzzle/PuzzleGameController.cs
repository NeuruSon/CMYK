using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleGameController : MonoBehaviour
{
    //퍼즐 모드일 때의 게임 컨트롤러입니다.
    GameObject sCon, mainSoundBox;
    public GameObject puzzles, nextBtn, doneBtn, effect_bg, clear_spr, clear_bg_spr, fail_spr; //유니티 에디터에서 지정하는 옵션 
    public AudioClip jingle_cleared, jingle_failed;
    Dictionary<string, GameObject> puzzleCanvases;
    GameObject currentPuzzleCanvas;
    bool isCleared = false;

    void Awake()
    {
        puzzleCanvases = new Dictionary<string, GameObject>();
    }

    void Start()
    {
        mainSoundBox = GameObject.Find("mainSoundBox");
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
        if (isCleared)
        {
            clear_bg_spr.transform.Rotate(Vector3.forward * Time.deltaTime * 7.5f);
        }
    }

    IEnumerator waitForResult_cleared()
    {
        isCleared = true;
        mainSoundBox.GetComponent<GameSoundController>().on_pRightJINGLE();
        yield return new WaitForSeconds(3f);

        if (PlayData.preSceneName != null)
        {
            sCon.GetComponent<SceneController>().toScene(PlayData.preSceneName);
            PlayData.toPreScene = true;
        }
        else
        {
            sCon.GetComponent<SceneController>().toTitleScene();

        }
    }

    IEnumerator waitForResult_failed()
    {
        mainSoundBox.GetComponent<GameSoundController>().on_pWrongJINGLE();
        yield return new WaitForSeconds(3.5f);

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
        }
    }

    public void result_cleared()
    {
        effect_bg.SetActive(true);
        clear_spr.SetActive(true);
        clear_bg_spr.SetActive(true);
        StartCoroutine(waitForResult_cleared());
    }

    public void result_failed()
    {
        effect_bg.SetActive(true);
        fail_spr.SetActive(true);
        StartCoroutine(waitForResult_failed());
    }

    public void checkAnswer()
    {
        //dictionary에서 key를 이용해 value의 index를 반환하고, 해당 값을 npcNum 대신 보내줌
        if (currentPuzzleCanvas.GetComponent<PuzzleAnswerController>().checkAnswer(puzzleCanvases.Keys.ToList().IndexOf(PlayData.puzzleName)))
        {
            result_cleared();
        }
        else
        {
            result_failed();
        }
    }

    public void checkAnswer_tag()
    {
        //dictionary에서 key를 이용해 value의 index를 반환하고, 해당 값을 npcNum 대신 보내줌
        if (currentPuzzleCanvas.GetComponent<PuzzleAnswerController>().checkAnswer_tag(puzzleCanvases.Keys.ToList().IndexOf(PlayData.puzzleName)))
        {
            result_cleared();
        }
        else
        {
            result_failed();
        }
    }

    public void quitPuzzle()
    {
        sCon.GetComponent<SceneController>().toScene(PlayData.preSceneName);
        PlayData.toPreScene = true;
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
