using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSubSoundController : MonoBehaviour
{
    AudioSource audio_source;

    [Header("sub")]
    public AudioClip in_sfx;
    public AudioClip save_sfx;

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
        audio_source = GetComponent<AudioSource>();
        audio_source.playOnAwake = true;
        audio_source.loop = false;
    }

    void Update()
    {

    }

    public void on_effectSFX()
    {
        audio_source.clip = effect_sfx;
        audio_source.Play();
    }

    public void on_saveSFX()
    {
        audio_source.clip = save_sfx;
        audio_source.Play();
    }

    public void on_inSFX()
    {
        audio_source.clip = in_sfx;
        audio_source.Play();
    }

    public void on_flowchartJINGLE()
    {
        audio_source.clip = flowchart_win_jignle;
        audio_source.Play();
    }

    public void on_flowchartSFX()
    {
        audio_source.clip = flowchart_sfx;
        audio_source.Play();
    }

    public void on_pRightJINGLE()
    {
        audio_source.clip = puzzle_right_jingle;
        audio_source.Play();
    }

    public void on_pWrongJINGLE()
    {
        audio_source.clip = puzzle_wrong_jingle;
        audio_source.Play();
    }

    public void on_lightOnJINGLE()
    {
        audio_source.clip = light_on_jingle;
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