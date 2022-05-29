using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //모험 모드일 때의 게임 컨트롤러입니다.

    public GameObject guideImage; //유니티 에디터에서 지정하는 옵션 
    public GameObject settingCanvas; //유니티 에디터에서 지정하는 옵션
    public GameObject reAskTitle_panel; //유니티 에디터에서 지정하는 옵션
    public Slider bright_slider, bgm_slider, sfx_slider;
    private bool isGuideOn = false, isSettingOn = false;
    GameObject pCon, cCon;
    public GameObject soundBox;

    public bool isPaused = false;

    void Start()
    {
        if (PlayData.toPreScene == true)
        {
            setPosition();
        }
        bright_slider.value = PlayData.curBrightness;
        bgm_slider.value = PlayData.curBgmVolume;
        sfx_slider.value = PlayData.curSfxVolume; 

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
        else if (Input.GetKeyDown(KeyCode.G) && isSettingOn == true)
        {
            isSettingOn = false;
            settingCanvas.SetActive(false);
            isGuideOn = true;
            guideImage.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettingOn == true)
            {
                isSettingOn = false;
                settingCanvas.SetActive(false);
            }
            else
            {
                isSettingOn = true;
                settingCanvas.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isGuideOn == true)
        {
            isGuideOn = false;
            guideImage.SetActive(false);
            isSettingOn = true;
            settingCanvas.SetActive(true);
        }

        if (isSettingOn || isGuideOn)
        {
            isPaused = true;

            Screen.brightness = bright_slider.value;
            soundBox.GetComponent<AudioSource>().volume = bgm_slider.value;
        }
        else
        {
            isPaused = false;
        }
    }
    public void openSettingPanel()
    {
        isSettingOn = true;
        settingCanvas.SetActive(true);
    }

    public void closeBtn()
    {
        isSettingOn = false;
        settingCanvas.SetActive(false);
        PlayData.curBrightness = bright_slider.value;
        PlayData.curBgmVolume = bgm_slider.value;
        PlayData.curSfxVolume = sfx_slider.value;

        isGuideOn = false;
        guideImage.SetActive(false);
    }

    public void reAskTitle()
    {
        reAskTitle_panel.SetActive(true);
    }

    public void closeReAskTitle()
    {
        reAskTitle_panel.SetActive(false);
    }

    void setPosition()
    {
        PlayData.toPreScene = false;
        pCon = GameObject.Find("Player");
        pCon.GetComponent<Transform>().transform.localPosition = PlayData.preSceneLocation; //player를 이전 씬과 동일하게 배치
        int childCount = pCon.transform.childCount;
        for (int i = 0; i < childCount; ++i)
        {
            pCon.transform.GetChild(i).GetComponent<Transform>().transform.localEulerAngles = PlayData.preSceneRotation; //player를 이전 씬과 동일하게 배치
        }

        cCon = GameObject.Find("Continue");
        cCon.GetComponent<Transform>().transform.localPosition = PlayData.preSceneLocation + cCon.GetComponent<ContinueController>().offset;
    }
}