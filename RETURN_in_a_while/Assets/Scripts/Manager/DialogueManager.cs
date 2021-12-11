using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] public GameObject go_DialogueBar;
    [SerializeField] public GameObject go_DialogueNameBar;

    [SerializeField] Text txt_Dialogue;
    [SerializeField] Text txt_Name;

    [SerializeField] Button okbtn;
    [SerializeField] Button nobtn;

    [Header("텍스트 출력 딜레이")]
    [SerializeField] float textDelay; // 대사 주르륵 나타나는 효과 

    Dialogue[] dialogues;

    public InteractionController IC;

    bool isDialogue = false; // 대화중일땐 true
    bool isNext = false; // 입력 대기 

    int lineCount = 0; // 대화카운트, 대화가 종료되면 +1하고 다음 캐릭터 대사 진행 
    int contextCount = 0; // 대사 카운트 

    public static bool gotoPuzzle = false;

    void Update()
    {
        if (isDialogue)
        {
            if (isNext)
            {
                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    isNext = false;
                    txt_Dialogue.text = "";
                    
                    if(++contextCount < dialogues[lineCount].contexts.Length) // 한 캐릭터 대사 모두 출력될때까지 반복 
                    {
                        StartCoroutine(Typewriter());
                    }
                    // 다음 캐릭터로 넘어가고 인덱스는 0번으로 다시 초기화
                    else
                    {
                        contextCount = 0;
                        if(++lineCount < dialogues.Length)
                        {
                            StartCoroutine(Typewriter());
                        }
                        else
                        {
                            // 모든 대화가 끝난 경우
                            
                            gotoPuzzle = true;
                            EndDialogue();
                            if (DialogueManager.gotoPuzzle == true)
                            {
                               // NPCController.sCon.GetComponentInChildren<SceneController>().toPuzzleScene();
                            }
                        }
                    }
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
        IC.HideUI();
       
        dialogues = pdialogues;
        StartCoroutine(Typewriter());
       //
    }

    void SettingUI(bool tf)
    {
        go_DialogueBar.SetActive(tf);
        if (tf)
        {
            if(dialogues[lineCount].name=="")
            {
                //나레이션일 경우
                go_DialogueNameBar.SetActive(false);
            }
            else
            {
                if (dialogues[lineCount].number.Equals("1"))
                {
                    // 1번 분기점일 경우 
                    okbtn.gameObject.SetActive(true);
                    nobtn.gameObject.SetActive(true);


                }
                go_DialogueNameBar.SetActive(tf);
                txt_Name.text = dialogues[lineCount].name;
            }
            

        }
       
    }

    void EndDialogue()
    {
        go_DialogueNameBar.SetActive(false);
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        isNext = false;
        SettingUI(false); // ui 사라짐
    }

    IEnumerator Typewriter()
    {
        SettingUI(true);
        string t_ReplaceText = dialogues[lineCount].contexts[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("'", ","); // 콤마가 안돼서 콤마 대신 ' 씀, 그거 replace해줌 
        
        
        for(int i = 0; i<t_ReplaceText.Length; i++)
        {
            txt_Dialogue.text += t_ReplaceText[i];
            yield return new WaitForSeconds(textDelay);
        }
        isNext = true;

        yield return null;
    }

}
