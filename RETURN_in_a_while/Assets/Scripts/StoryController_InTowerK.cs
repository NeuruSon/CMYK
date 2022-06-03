using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController_InTowerK : MonoBehaviour
{
    public AudioClip breakBGM, guardiansBGM, windBGM, pastBGM, byeBGM;
    GameObject mainSoundBox;

    void Start()
    {
        mainSoundBox = GameObject.Find("mainSoundBox");
    }

    public void break_bgm()
    {
        mainSoundBox.GetComponent<GameMainSoundController>().field_bgm = breakBGM;
        mainSoundBox.GetComponent<GameMainSoundController>().on_fieldBGM();
    }

    public void guardians_bgm()
    {
        mainSoundBox.GetComponent<GameMainSoundController>().field_bgm = guardiansBGM;
        mainSoundBox.GetComponent<GameMainSoundController>().on_fieldBGM();
    }

    public void wind_bgm()
    {
        mainSoundBox.GetComponent<GameMainSoundController>().field_bgm = windBGM;
        mainSoundBox.GetComponent<GameMainSoundController>().on_fieldBGM();
    }

    public void past_bgm()
    {
        mainSoundBox.GetComponent<GameMainSoundController>().field_bgm = pastBGM;
        mainSoundBox.GetComponent<GameMainSoundController>().on_fieldBGM();
    }

    public void bye_bgm()
    {
        mainSoundBox.GetComponent<GameMainSoundController>().field_bgm = byeBGM;
        mainSoundBox.GetComponent<GameMainSoundController>().on_fieldBGM();
    }

    public void getVolumeBack()
    {
        mainSoundBox.GetComponent<AudioSource>().volume = PlayData.curBgmVolume;
    }
}