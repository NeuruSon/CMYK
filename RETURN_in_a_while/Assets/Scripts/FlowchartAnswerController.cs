using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowchartAnswerController : MonoBehaviour
{
    GameObject gCon;
    public GameObject soundBox, effect_bg, clear_spr, clear_bg_spr, char_spr; //유니티 에디터에서 지정하는 옵션
    public Sprite mono_heart, color_heart, mono_char, color_char;
    public List<GameObject> hearts;
    public AudioClip jingle_cleared;
    AudioSource audio;
    public List<GameObject> slots; //유니티 에디터에서 지정하는 옵션 
    public List<bool> answers;
    bool isCleared = false;

    void Start()
    {
        gCon = GameObject.Find("GameController");
        //다른 곳에서 flowchart를 열 때 꼭 잘 isPaused = true; 해줘야 합니다!
        gCon.GetComponent<GameController>().isPaused = true;

        audio = soundBox.GetComponent<AudioSource>();

        answers = new List<bool>();
        for (int i = 0; i < slots.Count; ++i)
        {
            answers.Add(slots[i].GetComponent<DADSlotController>().isCorrect());
        }
    }

    void Update()
    {
        if (!isCleared && checkAnswer())
        {
            isCleared = true;

            //cleared!!
            Debug.Log("true"); //한번만 떠야 정상
            char_spr.GetComponent<Image>().sprite = color_char;
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
                hearts[i].GetComponent<Image>().sprite = color_heart;
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

        audio.GetComponent<GameSoundController>().on_mainBGM();
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
