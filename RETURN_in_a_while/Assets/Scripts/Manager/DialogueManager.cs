using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_DialogueNameBar;

    [SerializeField] Text txt_Dialogue;
    [SerializeField] Text txt_Name;

    Dialogue[] dialogues;


    bool isDialogue = false; // 대화중일땐 true
    bool isNext = false; // 입력 대기 

    int lineCount = 0; // 대화카운트, 대화가 종료되면 +1하고 다음 캐릭터 대사 진행 
    int contextCount = 0; // 대사 카운트 

    void Update()
    {
        if (isDialogue)
        {
            if (isNext)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    isNext = false;
                    txt_Dialogue.text = "";
                    StartCoroutine(Typewriter());
                    ++contextCount;
                    //txt_Name.text = "";
                }
            }
        }
    }
    public void ShowDialogue(Dialogue[] pdialogues)
    {
        isDialogue = true;
        txt_Dialogue.text = "";
        txt_Name.text = "";
        SettingUI(true);
        dialogues = pdialogues;
        StartCoroutine(Typewriter());
       //
    }

    void SettingUI(bool tf)
    {
        go_DialogueBar.SetActive(tf);
        go_DialogueNameBar.SetActive(tf);
    }

    public void HideUI()
    {
        go_DialogueBar.SetActive(false);
        go_DialogueNameBar.SetActive(false);
    }


    IEnumerator Typewriter()
    {
        SettingUI(true);
        string t_ReplaceText = dialogues[lineCount].contexts[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("'", ","); // 콤마가 안돼서 콤마 대신 ' 씀, 그거 replace해줌 
        txt_Dialogue.text = t_ReplaceText;
        isNext = true;

        yield return null;
    }

}
