using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainSoundController : MonoBehaviour
{
    
    AudioSource audio;

    [Header("main")]
    public AudioClip field_bgm;

    [Header("flowchart")]
    public AudioClip flowchart_bgm;

    [Header("puzzle")]
    public AudioClip puzzle_bgm;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.playOnAwake = true;
        audio.loop = true;
        audio.clip = field_bgm;
        audio.Play();
    }

    void Update()
    {
        
    }

    public void on_puzzleBGM()
    {
        audio.clip = puzzle_bgm;
        audio.Play();
    }

    public void on_fieldBGM()
    {
        audio.clip = field_bgm;
        audio.Play();
    }

    public void on_flowchartBGM()
    {
        audio.clip = flowchart_bgm;
        audio.Play();
    }

    public void pause_audio()
    {
        audio.Pause();
    }

    public void stop_audio()
    {
        audio.Stop();
    }
}