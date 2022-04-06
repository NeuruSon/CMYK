using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //모험 모드일 때의 게임 컨트롤러입니다.

    public GameObject guideImage; //유니티 에디터에서 지정하는 옵션 
    public GameObject settingCanvas; //유니티 에디터에서 지정하는 옵션 
    private bool isGuideOn = false, isSettingOn = false;
    GameObject pCon;

    public bool isPaused = false;

    private void Awake()
    {
        pCon = GameObject.Find("Player");
        pCon.GetComponent<Transform>().transform.localPosition = PlayData.preSceneLocation; //player를 이전 씬과 동일하게 배치
        pCon.GetComponent<Transform>().transform.localRotation = PlayData.preSceneRotation; //player를 이전 씬과 동일하게 배치 
    }

    void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && isSettingOn == false) //setting 창이 켜진 상태에서는 가이드 이미지를 띄우지 못함.
        {
            if (isGuideOn == true)
            {
                isGuideOn = false;
                guideImage.SetActive(false);
            }
            else
            {
                isGuideOn = true;
                guideImage.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettingOn == true)
            {
                isSettingOn = false;
                settingCanvas.SetActive(false);
                //setting off
            }
            else
            {
                isSettingOn = true;
                settingCanvas.SetActive(true);
                //setting on
            }
        }

        if (isSettingOn || isGuideOn)
        {
            isPaused = true;
        }
        
    }
}
