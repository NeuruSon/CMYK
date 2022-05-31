using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //모험 모드일 때의 게임 컨트롤러입니다.

    public GameObject guideImage; //유니티 에디터에서 지정하는 옵션 
    public GameObject settingCanvas; //유니티 에디터에서 지정하는 옵션
    public GameObject reAskTitle_panel; //유니티 에디터에서 지정하는 옵션
    Slider bright_slider, bgm_slider, sfx_slider;
    private bool isGuideOn = false, isSettingOn = false;
    GameObject pCon, cCon;
    GameObject mainSoundBox, soundBox, dialogueAudio;
    public AudioClip click_sfx;
    AudioSource audio;

    public bool isPaused = false;

    void Start()
    {
        mainSoundBox = GameObject.Find("mainSoundBox");
        soundBox = GameObject.Find("soundBox");
        dialogueAudio = GameObject.Find("SayDialog");
        audio = GetComponent<AudioSource>();
        audio.clip = click_sfx;
        audio.loop = false;

        settingCanvas.SetActive(true);

        for (int i = 0; i < 3; ++i)
        {
            if (FindObjectsOfType(typeof(Slider))[i].name == "bright_slider")
            {
                bright_slider = (Slider)FindObjectsOfType(typeof(Slider))[i];
            }
            else if (FindObjectsOfType(typeof(Slider))[i].name == "bgm_slider")
            {
                bgm_slider = (Slider)FindObjectsOfType(typeof(Slider))[i];
            }
            else if (FindObjectsOfType(typeof(Slider))[i].name == "sfx_slider")
            {
                sfx_slider = (Slider)FindObjectsOfType(typeof(Slider))[i];
            }
        }

        bright_slider.wholeNumbers = false;
        bgm_slider.wholeNumbers = false;
        sfx_slider.wholeNumbers = false;

        bright_slider.minValue = 0.5f;
        bright_slider.maxValue = 2.35f;
        bgm_slider.minValue = 0f;
        bgm_slider.maxValue = 1f;
        sfx_slider.minValue = 0f;
        sfx_slider.maxValue = 1f;

        bright_slider.value = PlayData.curBrightness;
        bgm_slider.value = PlayData.curBgmVolume;
        sfx_slider.value = PlayData.curSfxVolume;
        dialogueAudio.GetComponent<WriterAudio>().volume = PlayData.curSfxVolume;
        gameObject.GetComponent<AudioSource>().volume = PlayData.curSfxVolume;

        RenderSettings.ambientIntensity = PlayData.curBrightness;
        mainSoundBox.GetComponent<AudioSource>().volume = PlayData.curBgmVolume;
        soundBox.GetComponent<AudioSource>().volume = PlayData.curSfxVolume;

        settingCanvas.SetActive(false);


        if (PlayData.toPreScene == true)
        {
            setPosition();
        }

        isPaused = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //particle
        }

        if (Input.GetMouseButtonDown(0))
        {
            audio.Play();
        }

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

            PlayData.curBrightness = bright_slider.value;
            PlayData.curBgmVolume = bgm_slider.value;
            PlayData.curSfxVolume = sfx_slider.value;
            settingCanvas.SetActive(false);

            isGuideOn = true;
            guideImage.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isGuideOn == true)
        {
            isGuideOn = false;
            guideImage.SetActive(false);

            isSettingOn = true;
            settingCanvas.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isGuideOn == false)
        {
            if (isSettingOn == true)
            {
                PlayData.curBrightness = bright_slider.value;
                PlayData.curBgmVolume = bgm_slider.value;
                PlayData.curSfxVolume = sfx_slider.value;
                settingCanvas.SetActive(false);

                isSettingOn = false;
            }
            else
            {
                settingCanvas.SetActive(true);
                bright_slider.value = RenderSettings.ambientIntensity;
                bgm_slider.value = mainSoundBox.GetComponent<AudioSource>().volume;
                sfx_slider.value = soundBox.GetComponent<AudioSource>().volume;

                isSettingOn = true;
            }
        }

        if (isSettingOn || isGuideOn)
        {
            isPaused = true;

            RenderSettings.ambientIntensity = bright_slider.value;
            mainSoundBox.GetComponent<AudioSource>().volume = bgm_slider.value;
            soundBox.GetComponent<AudioSource>().volume = sfx_slider.value;
            dialogueAudio.GetComponent<WriterAudio>().volume = sfx_slider.value;
            gameObject.GetComponent<AudioSource>().volume = sfx_slider.value;
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
        PlayData.curBrightness = bright_slider.value;
        PlayData.curBgmVolume = bgm_slider.value;
        PlayData.curSfxVolume = sfx_slider.value;
        settingCanvas.SetActive(false);

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