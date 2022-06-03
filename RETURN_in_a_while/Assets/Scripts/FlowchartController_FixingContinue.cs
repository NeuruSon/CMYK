using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowchartController_FixingContinue : MonoBehaviour
{
    public GameObject mainSoundBox, block_int, block_char, block_bool, block_array;
    AudioSource audio_source;
    GameObject gCon, soundBox;
    public GameObject effect_bg, clear_spr, clear_bg_spr; //유니티 에디터에서 지정하는 옵션
    public AudioClip jingle_cleared;
    public List<GameObject> slots; //유니티 에디터에서 지정하는 옵션 
    public List<bool> answers;
    bool isCleared = false, isEnded = false;

    void Start()
    {
        gCon = GameObject.Find("GameController");
        soundBox = GameObject.Find("soundBox");

        answers = new List<bool>();
        for (int i = 0; i < slots.Count; ++i)
        {
            answers.Add(slots[i].GetComponent<DADSlotController>().isCorrect());
        }
    }

    void Update()
    {
        gCon.GetComponent<GameController>().isPaused = true;

        if (slots[0].GetComponent<DADSlotController>().isCorrect())
        {
            block_int.SetActive(true);
        }
        else
        {
            block_int.SetActive(false);
        }

        if (slots[1].GetComponent<DADSlotController>().isCorrect())
        {
            block_char.SetActive(true);
        }
        else
        {
            block_char.SetActive(false);
        }

        if (slots[2].GetComponent<DADSlotController>().isCorrect())
        {
            block_bool.SetActive(true);
        }
        else
        {
            block_bool.SetActive(false);
        }

        if (slots[3].GetComponent<DADSlotController>().isCorrect())
        {
            block_array.SetActive(true);
        }
        else
        {
            block_array.SetActive(false);
        }

        if (!isCleared && checkAnswer())
        {
            isCleared = true;

            //cleared!!
            Debug.Log("true"); //한번만 떠야 정상
            result_cleared();
        }

        if (isCleared && !isEnded)
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
        //Debug.Log(answer);

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
        mainSoundBox.GetComponent<GameMainSoundController>().stop_audio();
        soundBox.GetComponent<GameSubSoundController>().on_flowchartJINGLE();
        yield return new WaitForSeconds(6.5f);

        mainSoundBox.GetComponent<GameMainSoundController>().on_fieldBGM();
        gCon.GetComponent<GameController>().isPaused = false;
        isEnded = true;
        effect_bg.SetActive(false);
        clear_spr.SetActive(false);
        clear_bg_spr.SetActive(false);
        gameObject.SetActive(false);
    }

    void result_cleared()
    {
        effect_bg.SetActive(true);
        clear_spr.SetActive(true);
        clear_bg_spr.SetActive(true);

        PlayData.isFlowchartCleared[0] = true;
        StartCoroutine(waitForResult_cleared());
    }
}
