using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject sCon, player;

    void Start()
    {
        sCon = GameObject.Find("SceneController");
        player = GameObject.Find("Hero");
    }

    public void saveCurrentPosition()
    {
        PlayData.preSceneLocation = GetComponent<Transform>().transform.localPosition; //현재 플레이어의 위치를, 복귀할 때의 위치 선정을 위해 임시저장
        PlayData.preSceneRotation = player.GetComponent<Transform>().transform.localRotation.eulerAngles; //현재 플레이어의 각도를, 복귀할 때의 각도 지정을 위해 임시저장

        Debug.Log(GetComponent<Transform>().transform.localPosition);
        Debug.Log(player.GetComponent<Transform>().transform.localRotation.eulerAngles);
        Debug.Log(PlayData.preSceneLocation);
        Debug.Log(PlayData.preSceneRotation);
    }

    public void saveCurrentSceneName()
    {
        PlayData.preSceneName = sCon.GetComponent<SceneController>().getThisSceneName();
        Debug.Log(PlayData.preSceneName);
    }
}