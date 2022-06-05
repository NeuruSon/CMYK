using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingController : MonoBehaviour
{
    TextMeshProUGUI and_you_tmp;
    public TextMeshProUGUI askContinue_tmp;
    string askContinue_text = "";
    public GameObject save_panel, askSave_panel, askContinue_panel, waitForSave_panel;
    GameObject staffRoll_panel, logo_spr, mainSoundBox, soundBox, team_panel, fade_panel, and_you_panel;
    bool isStarted = false, isEnded = false, flag_1 = false, flag_2 = false, flag_3 = false, flag_4 = false, flag_5 = false, flag_6 = false, flag_7 = false;
    float speed = 137f, scale_speed = 0.3f, fade_speed = 0.2f;

    void Start()
    {
        mainSoundBox.GetComponent<AudioSource>().volume = PlayData.curBgmVolume;
        soundBox.GetComponent<AudioSource>().volume = PlayData.curSfxVolume;

        fade_panel = GameObject.Find("fade_panel");
        and_you_panel = GameObject.Find("and_you_bold");
        and_you_tmp = GameObject.Find("and_you_black").GetComponent<TextMeshProUGUI>();
        and_you_tmp.text = PlayData.playerName;
        mainSoundBox = GameObject.Find("mainSoundBox");
        soundBox = GameObject.Find("soundBox");
        staffRoll_panel = GameObject.Find("staffRoll_panel");
        logo_spr = GameObject.Find("logo_spr");
        team_panel = GameObject.Find("staffRoll_tmp_black_제작");
        askContinue_text = askContinue_tmp.text;
        isStarted = true;
        mainSoundBox.GetComponent<GameMainSoundController>().on_fieldBGM();

        Invoke("turnOn_f1", 6f);
        Invoke("turnOn_f2", 9f);
        Invoke("turnOn_f3", 10f);
        Invoke("turnOn_f4", 26f);
        Invoke("turnOn_f5", 79f);
        Invoke("turnOn_f6", 83f);
        Invoke("turnOn_f7", 88f);

        Invoke("end", 95f);
    }

    void Update()
    {
        //10157
        if (isStarted)
        {
            fade_panel.GetComponent<CanvasGroup>().alpha -= fade_speed * Time.deltaTime;
        }

        if (flag_1)
        {
            logo_spr.transform.localScale = Vector3.Lerp(logo_spr.transform.localScale, new Vector3(0.5f, 0.5f, 1f), scale_speed * Time.deltaTime);
        }

        if (flag_2)
        {
            staffRoll_panel.transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }

        if (flag_3)
        {
            logo_spr.transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
            team_panel.transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }

        if (flag_4)
        {

        }

        if (flag_5)
        {
            team_panel.transform.localPosition = Vector3.Lerp(team_panel.transform.localPosition, new Vector3(0f, 30f, 0f), scale_speed * Time.deltaTime);
        }

        if (flag_6)
        {
            fade_panel.GetComponent<CanvasGroup>().alpha += fade_speed * Time.deltaTime;
        }

        if (flag_7)
        {
            and_you_panel.GetComponent<CanvasGroup>().alpha += fade_speed * Time.deltaTime;
        }

        if (isEnded)
        {
            isEnded = false;
            save_panel.SetActive(true);
            soundBox.GetComponent<GameSubSoundController>().on_effectSFX();
        }
    }

    void turnOn_f1()
    {
        flag_1 = true;
        mainSoundBox.GetComponent<AudioSource>().loop = false;
    }

    void turnOn_f2()
    {
        flag_2 = true;
        isStarted = false;
    }

    void turnOn_f3()
    {
        flag_1 = false;
        flag_3 = true;
    }

    void turnOn_f4()
    {
        flag_4 = true;
    }

    void turnOn_f5()
    {
        flag_3 = false;
        flag_5 = true;
    }

    void turnOn_f6()
    {
        flag_2 = false;
        flag_6 = true;
    }

    void turnOn_f7()
    {
        flag_7 = true;
    }

    void end()
    {
        isEnded = true;
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
        waitForSave_panel.SetActive(false);
        askContinue_tmp.text = PlayData.curSaveSlotNum + askContinue_text;
        askContinue_panel.SetActive(true);
    }
}
