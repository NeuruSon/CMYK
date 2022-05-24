using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEventController : MonoBehaviour
{
    public GameObject light_guide_spr, light_spr;
    bool isLightOn = false;
    GameObject mainSoundBox;

    void Start()
    {
        mainSoundBox = GameObject.Find("mainSoundBox");
    }

    void Update()
    {
        if (light_spr.activeInHierarchy == true && isLightOn == false && Input.GetKeyDown(KeyCode.E))
        {
            isLightOn = true;
            light_spr.SetActive(false);
            light_guide_spr.SetActive(false);
            mainSoundBox.GetComponent<GameSoundController>().on_flowchartJINGLE();
            Invoke("returnBGM", 10);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (isLightOn == false && col.CompareTag("Player"))
        {
            light_spr.SetActive(true);
            light_guide_spr.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        light_spr.SetActive(false);
        light_guide_spr.SetActive(false);
    }

    void returnBGM()
    {
        mainSoundBox.GetComponent<GameSoundController>().on_fieldBGM();
    }
}
