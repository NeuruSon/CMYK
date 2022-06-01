using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSubSoundController : MonoBehaviour
{
    AudioSource audio;

    [Header("sub")]
    public AudioClip in_sfx;

    [Header("tower")]
    public AudioClip light_on_jingle;

    [Header("flowchart")]
    public AudioClip flowchart_win_jignle;
    public AudioClip flowchart_sfx;

    [Header("puzzle")]
    public AudioClip puzzle_right_jingle;
    public AudioClip puzzle_wrong_jingle;
    public AudioClip effect_sfx;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.playOnAwake = true;
        audio.loop = false;
    }

    void Update()
    {

    }

    public void on_effectSFX()
    {
        audio.clip = effect_sfx;
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

    public void on_lightOnJINGLE()
    {
        audio.clip = light_on_jingle;
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