using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController_InTowerM_2 : MonoBehaviour
{
    GameObject mainSoundBox;
    public AudioClip kkaebu_sacrifice_bgm;

    void Start()
    {
        mainSoundBox = GameObject.Find("mainSoundBox");
        mainSoundBox.GetComponent<GameMainSoundController>().field_bgm = kkaebu_sacrifice_bgm; 
        mainSoundBox.GetComponent<GameMainSoundController>().on_fieldBGM();
    }
}
