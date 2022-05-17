using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowchartController_FixingContinue : MonoBehaviour
{
    public GameObject mainSoundBox, soundBox, block_int, block_char, block_bool, block_array;
    public AudioClip right_sfx, wrong_sfx;
    AudioSource mainAudio, audio;
    bool b_1 = false, b_2 = false, b_3 = false, b_4 = false;
    GameObject gCon;
    public GameObject effect_bg, clear_spr, clear_bg_spr; //유니티 에디터에서 지정하는 옵션
    public AudioClip jingle_cleared;
    public List<GameObject> slots; //유니티 에디터에서 지정하는 옵션 
    public List<bool> answers;
    bool isCleared = false;

    void Start()
    {
        gCon = GameObject.Find("GameController");
        //다른 곳에서 flowchart를 열 때 꼭 잘 isPaused = true; 해줘야 합니다!
        gCon.GetComponent<GameController>().isPaused = true;

        mainAudio = mainSoundBox.GetComponent<AudioSource>();
        audio = soundBox.GetComponent<AudioSource>();

        answers = new List<bool>();
        for (int i = 0; i < slots.Count; ++i)
        {
            answers.Add(slots[i].GetComponent<DADSlotController>().isCorrect());
        }
    }

    void Update()
    {
        if (answers[0] && !b_1)
        {
            b_1 = true;
            audio.clip = right_sfx;
            audio.Play();
            block_int.SetActive(true);
        }

        if (answers[1] && !b_2)
        {
            b_2 = true;
            audio.clip = right_sfx;
            audio.Play();
            block_char.SetActive(true);
        }

        if (answers[2] && !b_3)
        {
            b_3 = true;
            audio.clip = right_sfx;
            audio.Play();
            block_bool.SetActive(true);
        }

        if (answers[3] && !b_4)
        {
            b_4 = true;
            audio.clip = right_sfx;
            audio.Play();
            block_array.SetActive(true);
        }

        if (!isCleared && checkAnswer())
        {
            isCleared = true;

            //cleared!!
            Debug.Log("true"); //한번만 떠야 정상
            result_cleared();
        }

        if (isCleared)
        {
            clear_bg_spr.transform.Rotate(Vector3.forward * Time.deltaTime * 7.5f);
        }
    }
    public bool checkAnswer()
    {
        string answer = "";
        for (int i = 0; i < slots.Count; ++i)
        {
            answers[i] = slots[i].GetComponent<DADSlotController>().isCorrect();
            if (answers[i])
            {
                answer += "1";
            }
            else answer += "0";
        }
        Debug.Log(answer);

        if (answers.Contains(false)) //오답이 하나라도 있을 경우
        {
            return false;
        }
        else //다 맞았다면 
        {
            return true;
        }
    }

    IEnumerator waitForResult_cleared()
    {
        isCleared = true;
        audio.clip = jingle_cleared;
        audio.Play();
        yield return new WaitForSeconds(6.5f);

        mainAudio.GetComponent<GameSoundController>().on_mainBGM();
        gameObject.SetActive(false);
        gCon.GetComponent<GameController>().isPaused = false;
    }

    void result_cleared()
    {
        effect_bg.SetActive(true);
        clear_spr.SetActive(true);
        clear_bg_spr.SetActive(true);
        StartCoroutine(waitForResult_cleared());
    }
}
