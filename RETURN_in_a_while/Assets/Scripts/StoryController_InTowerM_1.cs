using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController_InTowerM_1 : MonoBehaviour
{
    GameObject mainSoundBox;

    void Start()
    {
        mainSoundBox = GameObject.Find("mainSoundBox");
        mainSoundBox.GetComponent<GameMainSoundController>().stop_audio();
    }
}
