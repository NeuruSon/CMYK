using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    GameObject sCon, gCon, pCon;
    bool isActive = false;
    public GameObject quad; //유니티 에디터에서 지정하는 옵션 
    public string puzzleName = ""; //유니티 에디터에서 지정하는 옵션; 인터렉션했을 때 퍼즐씬에서 오픈할 퍼즐 name 저장 

    void Awake()
    {
        sCon = GameObject.Find("SceneController");
        gCon = GameObject.Find("GameController");
        pCon = GameObject.Find("Player");
    }

    void Update()
    {
        if (isActive == true)
        {
            quad.SetActive(true);
        }
        else if (isActive != true)
        {
            quad.SetActive(false);
        }

        if (isActive == true && Input.GetKeyDown(KeyCode.E))
        {
            PlayData.puzzleName = puzzleName; //본 NPC의 puzzle name을, puzzle scene에서 사용하기 위해 임시저장
            pCon.GetComponent<PlayerController>().saveCurrentPosition();
            sCon.GetComponentInChildren<SceneController>().toPuzzleScene();
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
