using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlowchartAnswerController : MonoBehaviour
{
    GameObject gCon, mainSoundBox, soundBox;
    public int flowchartNum;
    string text;
    public TextMeshProUGUI flee_name_tmp;
    public GameObject effect_bg, clear_spr, clear_bg_spr, char_spr, flee_panel; //유니티 에디터에서 지정하는 옵션
    public Sprite mono_heart, color_heart, mono_char, color_char;
    public List<GameObject> hearts;
    public List<GameObject> slots; //유니티 에디터에서 지정하는 옵션 
    public List<bool> answers;
    public AudioClip bgm;
    bool isCleared = false, isEnded = false;

    void Start()
    {
        mainSoundBox = GameObject.Find("mainSoundBox");
        soundBox = GameObject.Find("soundBox");
        mainSoundBox.GetComponent<GameMainSoundController>().flowchart_bgm = bgm;
        mainSoundBox.GetComponent<GameMainSoundController>().on_flowchartBGM();
        gCon = GameObject.Find("GameController");
        text = flee_name_tmp.text;
        
        answers = new List<bool>();
        for (int i = 0; i < slots.Count; ++i)
        {
            answers.Add(slots[i].GetComponent<DADSlotController>().isCorrect());
        }
    }

    void Update()
    {
        gCon.GetComponent<GameController>().isPaused = true;

        if (!isCleared && checkAnswer())
        {
            isCleared = true;

            //cleared!!
            Debug.Log("true"); //한번만 떠야 정상
            char_spr.GetComponent<Image>().sprite = color_char;
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
        PlayData.isFlowchartCleared[flowchartNum] = true;
        StartCoroutine(waitForResult_cleared());
    }

    public void flee()
    {
        flee_panel.SetActive(true);
        soundBox.GetComponent<GameSubSoundController>().on_pWrongJINGLE();
        flee_name_tmp.text = text + PlayData.playerName + "!";
    }

    public void close_flee()
    {
        flee_panel.SetActive(false);
    }
}
