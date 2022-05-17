using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundController : MonoBehaviour
{
    public AudioClip tutorial_bgm, flowchart_win_jignle;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void on_mainBGM()
    {
        audio.clip = tutorial_bgm;
        audio.Play();
    }
}
