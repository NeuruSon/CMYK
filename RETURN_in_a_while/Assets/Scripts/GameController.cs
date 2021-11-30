using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //모험 모드일 때의 게임 컨트롤러입니다.

    public GameObject guideImage;
    public GameObject settingCanvas;
    private bool isGuideOn = false, isSettingOn = false;

    void Start()
    {
        
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
    }
}
