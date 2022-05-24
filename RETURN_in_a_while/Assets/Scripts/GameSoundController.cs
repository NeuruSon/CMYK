using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundController : MonoBehaviour
{
    public AudioClip field_bgm, puzzle_bgm, flowchart_bgm, flowchart_win_jignle, in_sfx, puzzle_right_jingle, puzzle_wrong_jingle;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
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

    public void on_inSFX()
    {
        audio.clip = in_sfx;
        audio.Play();
    }

    public void on_flowchartJINGLE()
    {
        audio.clip = flowchart_win_jignle;
        audio.Play();
    }

    public void on_pRightJINGLE()
    {
        audio.clip = puzzle_right_jingle;
        audio.Play();
    }

    public void on_pWrongJINGLE()
    {
        audio.clip = puzzle_wrong_jingle;
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