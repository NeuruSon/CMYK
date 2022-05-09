using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   
    public void saveCurrentPosition()
    {
        PlayData.preSceneLocation = GetComponent<Transform>().transform.localPosition; //현재 플레이어의 위치를, 복귀할 때의 위치 선정을 위해 임시저장
        PlayData.preSceneRotation = GetComponent<Transform>().transform.rotation; //현재 플레이어의 각도를, 복귀할 때의 각도 지정을 위해 임시저장

        Debug.Log(GetComponent<Transform>().transform.localPosition);
        Debug.Log(GetComponent<Transform>().transform.rotation);
        Debug.Log(PlayData.preSceneLocation);
        Debug.Log(PlayData.preSceneRotation);
    }

    void OnTriggerEnter(Collider col)
    {
        NPCController.inPuzzle = true;
       
        if (col.gameObject.name == "4")
        {
            SceneManager.LoadScene("InTower");
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "T1")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                LightMgr.lightOn();
            }
        }
    }
}