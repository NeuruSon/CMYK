using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEventController : MonoBehaviour
{
    GameObject sCon;

    void Start()
    {
        sCon = GameObject.Find("SceneController");
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        NPCController.inPuzzle = true;

        if (gameObject.name == "4" && col.gameObject.name == "Player")
        {
            sCon.GetComponent<SceneController>().toTowerYScene();
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (gameObject.name == "5" && col.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                LightMgr.lightOn();
                ++PlayData.currentChapterNum;
            }
        }
    }
}
