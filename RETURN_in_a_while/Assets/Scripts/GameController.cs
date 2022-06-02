using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    //모험 모드일 때의 게임 컨트롤러입니다.

    public GameObject settingIcon, guideIcon;
    public GameObject guideImage; //유니티 에디터에서 지정하는 옵션 
    public GameObject settingCanvas; //유니티 에디터에서 지정하는 옵션
    public GameObject reAskTitle_panel; //유니티 에디터에서 지정하는 옵션
    public GameObject askSave_panel, askContinue_panel, waitForSave_panel;
    public TextMeshProUGUI askContinue_tmp;
    string askContinue_text = "";
    Slider bright_slider, bgm_slider, sfx_slider;
    private bool isGuideOn = false, isSettingOn = false, isFlowchartOn = false;
    GameObject pCon, cCon;
    GameObject mainSoundBox, soundBox, sayDialog;
    public AudioClip click_sfx;
    AudioSource audio_source;

    public bool isPaused = false, deisPaused = false, isFirst = false;

    void Start()
    {
        if (PlayData.playerName == "용사")
        {
            isFirst = true;
        }
        mainSoundBox = GameObject.Find("mainSoundBox");
        soundBox = GameObject.Find("soundBox");
        sayDialog = GameObject.Find("SayDialog");
        audio_source = GetComponent<AudioSource>();
        audio_source.clip = click_sfx;
        audio_source.loop = false;
        askContinue_text = askContinue_tmp.text;

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
        if (GameObject.Find("SayDialog"))
        {
            sayDialog.GetComponent<WriterAudio>().volume = PlayData.curSfxVolume;
        }
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
        if (isFirst && GameObject.Find("talk_spr"))
        {
            GameObject.Find("talk_spr").SetActive(false);
        }

        if (GameObject.Find("flowchartCanvas"))
        {
            isFlowchartOn = true;
            settingIcon.SetActive(false);
            guideIcon.SetActive(false);
            isSettingOn = false;
            isGuideOn = false;
        }
        else
        {
            isFlowchartOn = false;
            settingIcon.SetActive(true);
            guideIcon.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            audio_source.Play();
        }

        if (!isSettingOn)
        {
            settingCanvas.SetActive(false);
        }
        if (!isGuideOn)
        {
            guideImage.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.G) && isSettingOn == false && !isFlowchartOn) //setting 창이 켜진 상태에서는 가이드 이미지를 띄우지 못함.
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
        else if (Input.GetKeyDown(KeyCode.G) && isSettingOn == true && !isFlowchartOn)
        {
            isSettingOn = false;

            PlayData.curBrightness = bright_slider.value;
            PlayData.curBgmVolume = bgm_slider.value;
            PlayData.curSfxVolume = sfx_slider.value;
            settingCanvas.SetActive(false);

            isGuideOn = true;
            guideImage.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isGuideOn == true && !isFlowchartOn)
        {
            isGuideOn = false;
            guideImage.SetActive(false);

            isSettingOn = true;
            settingCanvas.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isGuideOn == false &&!isFlowchartOn)
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

        //isPaused check
        if (isSettingOn || isGuideOn)
        {
            tryPause();
            Time.timeScale = 0f;

            RenderSettings.ambientIntensity = bright_slider.value;
            mainSoundBox.GetComponent<AudioSource>().volume = bgm_slider.value;
            soundBox.GetComponent<AudioSource>().volume = sfx_slider.value;
            if (sayDialog)
            {
                sayDialog.GetComponent<WriterAudio>().volume = sfx_slider.value;
            }
            gameObject.GetComponent<AudioSource>().volume = sfx_slider.value;
        }
        else if (GameObject.Find("SayDialog") && deisPaused == false)
        {
            tryPause();
            Time.timeScale = 1f;
        }
        else if (GameObject.Find("NamingObject"))
        {
            tryPause();
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
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

    public void askSaveBtn()
    {
        askSave_panel.SetActive(true);
    }

    public void closeAskSavePanel()
    {
        askSave_panel.SetActive(false);
    }

    public void save()
    {
        PlayData.currentSceneName = GameObject.Find("SceneController").GetComponent<SceneController>().getThisSceneName();
        SaveController.saveDatas(PlayData.curSaveSlotNum);
        StartCoroutine(waitForSave());
    }

    IEnumerator waitForSave()
    {
        waitForSave_panel.SetActive(true);
        mainSoundBox.GetComponent<GameMainSoundController>().stop_audio();
        soundBox.GetComponent<GameSubSoundController>().on_saveSFX();
        yield return new WaitForSeconds(5.3f);
        mainSoundBox.GetComponent<GameMainSoundController>().on_fieldBGM();
        waitForSave_panel.SetActive(false);
        askContinue_tmp.text = PlayData.curSaveSlotNum + askContinue_text;
        askContinue_panel.SetActive(true);
    }

    public void acceptContinue()
    {
        askSave_panel.SetActive(false);
        askContinue_panel.SetActive(false);
        askContinue_tmp.text = askContinue_text;
        isSettingOn = false;
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

    public void get_item()
    {
        StartCoroutine(waitForItem());
    }

    IEnumerator waitForItem()
    {
        mainSoundBox.GetComponent<GameMainSoundController>().pause_audio();
        soundBox.GetComponent<GameSubSoundController>().on_effectSFX();
        yield return new WaitForSeconds(4f);
        mainSoundBox.GetComponent<GameMainSoundController>().resume_audio();
    }

    public void close_itemPanel(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void on_deisPaused()
    {
        deisPaused = true;
    }

    public void off_deisPaused()
    {
        deisPaused = false;
    }

    public void tryPause()
    {
        if (deisPaused)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }

    public void non_first()
    {
        isFirst = false;
    }
}