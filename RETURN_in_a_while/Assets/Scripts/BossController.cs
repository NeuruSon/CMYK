using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    GameObject sCon, gCon, pCon;
    bool isActive = false;
    //public int npcNum; //유니티 에디터에서 지정하는 옵션 
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
            //if (PlayData.isPuzzleCleared[npcNum - 1] < 1)
            //{
            //}
            //else
            //{
            //    //클리어 이후의 이벤트 
            //}
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
