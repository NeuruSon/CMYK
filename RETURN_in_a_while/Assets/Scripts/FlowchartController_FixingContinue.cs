using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowchartController_FixingContinue : MonoBehaviour
{
    public GameObject soundbox, block_int, block_char, block_bool, block_array;
    public AudioClip right_sfx, wrong_sfx;
    AudioSource audio;
    bool b_1 = false, b_2 = false, b_3 = false, b_4 = false;

    void Start()
    {
        audio = soundbox.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gameObject.GetComponent<FlowchartAnswerController>().answers[0] && !b_1)
        {
            b_1 = true;
            audio.clip = right_sfx;
            audio.Play();
            block_int.SetActive(true);
        }

        if (gameObject.GetComponent<FlowchartAnswerController>().answers[1] && !b_2)
        {
            b_2 = true;
            audio.clip = right_sfx;
            audio.Play();
            block_char.SetActive(true);
        }

        if (gameObject.GetComponent<FlowchartAnswerController>().answers[2] && !b_3)
        {
            b_3 = true;
            audio.clip = right_sfx;
            audio.Play();
            block_bool.SetActive(true);
        }

        if (gameObject.GetComponent<FlowchartAnswerController>().answers[3] && !b_4)
        {
            b_4 = true;
            audio.clip = right_sfx;
            audio.Play();
            block_array.SetActive(true);
        }
    }
}
