using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainSoundController : MonoBehaviour
{
    
    AudioSource audio_source;

    [Header("main")]
    public AudioClip field_bgm;

    [Header("flowchart")]
    public AudioClip flowchart_bgm;

    void Start()
    {
        audio_source = GetComponent<AudioSource>();
        audio_source.playOnAwake = true;
        audio_source.loop = true;
        audio_source.clip = field_bgm;
        audio_source.Play();
    }

    void Update()
    {
        
    }

    public void on_fieldBGM()
    {
        audio_source.clip = field_bgm;
        audio_source.Play();
    }

    public void on_flowchartBGM()
    {
        audio_source.clip = flowchart_bgm;
        audio_source.Play();
    }

    public void pause_audio()
    {
        audio_source.Pause();
    }

    public void stop_audio()
    {
        audio_source.Stop();
    }
}