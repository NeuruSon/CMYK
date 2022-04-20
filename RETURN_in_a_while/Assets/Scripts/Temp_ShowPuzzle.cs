using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_ShowPuzzle : MonoBehaviour
{
    public static GameObject sCon, gCon, pCon;
    bool isActive = false;
    public int npcNum; //유니티 에디터에서 지정하는 옵션 
    public string puzzleName = ""; //유니티 에디터에서 지정하는 옵션; 인터렉션했을 때 퍼즐씬에서 오픈할 퍼즐 name 저장 

    void Start()
    {
        pCon = GameObject.Find("GameController");
        sCon = GameObject.Find("SceneController");
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.E))
        {
            PlayData.puzzleName = puzzleName; //본 NPC의 puzzle name을, puzzle scene에서 사용하기 위해 임시저장
            sCon.GetComponent<SceneController>().toPuzzleCScene();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            isActive = false;
        }
    }
}
