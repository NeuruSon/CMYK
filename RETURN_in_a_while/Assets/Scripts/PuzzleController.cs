using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    //퍼즐 모드일 때의 게임 컨트롤러입니다.
    public GameObject puzzles;
    Dictionary<string, GameObject> puzzleCanvases;
    GameObject currentPuzzleCanvas;

    void Awake()
    {
        puzzleCanvases = new Dictionary<string, GameObject>();
    }

    void Start()
    {
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
        currentPuzzleCanvas.GetComponent<PuzzleAnswerController>().checkAnswer(puzzleCanvases.Keys.ToList().IndexOf(PlayData.puzzleName));
    }
}
