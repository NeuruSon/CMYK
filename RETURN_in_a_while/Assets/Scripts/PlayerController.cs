using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public DialogueManager DM;
    public static InteractionEvent[] IE;
    public InteractionEvent[] showIE;
    public GameObject flowChartCanvas;
    GameObject gCon, fCon;
   //bool waitFlowchart = false;
    
    void Start()
    {
      //  IE = FindObjectsOfType<InteractionEvent>();
        IE = FindObjectsOfType<InteractionEvent>();
        System.Array.Sort<InteractionEvent>(IE, (x, y) => string.Compare(x.name, y.name));
        showIE = IE;
        gCon = GameObject.Find("GameController");
        fCon = GameObject.Find("FlowchartController");
    }

    void Update()
    {
        
    }

    public void saveCurrentPosition()
    {
        PlayData.preSceneLocation = GetComponent<Transform>().transform.localPosition; //현재 플레이어의 위치를, 복귀할 때의 위치 선정을 위해 임시저장
        PlayData.preSceneRotation = GetComponent<Transform>().transform.rotation; //현재 플레이어의 각도를, 복귀할 때의 각도 지정을 위해 임시저장
       // NPCController.inPuzzle = true;
    }
    void OnTriggerEnter(Collider col)
    {
        NPCController.inPuzzle = true;
        if (col.gameObject.name == "0")
        {
           
            DM.ShowDialogue(IE[0].GetDialogue()); // 한번만 실행되도록 변경하기 
        }
        if(col.gameObject.name == "1")
        {
            
            DM.ShowDialogue(IE[1].GetDialogue());
        }
        if(col.gameObject.name == "2")
        {
            // 코루틴
            StartCoroutine(WaitForFlowchart());
            
        }
        if (col.gameObject.name == "3")
        {
            
            DM.ShowDialogue(IE[3].GetDialogue());
        }
        if(col.gameObject.name == "4")
        {
            SceneManager.LoadScene("InTower");
        }
        if(col.gameObject.name == "5")
        {
            
            DM.ShowDialogue(IE[0].GetDialogue());
            
        }
        if (col.gameObject.name == "6")
        {
            DM.ShowDialogue(IE[1].GetDialogue());

        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "5")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DM.ShowDialogue(IE[2].GetDialogue());
                LightMgr.lightOn();
            }
        }
    }
    IEnumerator WaitForFlowchart()
    {
        
        flowChartCanvas.SetActive(true);
        FlowchartController.isFlowchartOn = true;
        gCon.GetComponent<GameController>().isPaused = false;
        fCon.GetComponent<FlowchartSequenceController>().isStarted = true;

        yield return new WaitForSeconds(14.0f);

        flowChartCanvas.SetActive(false);
        FlowchartController.isFlowchartOn = false;
        gCon.GetComponent<GameController>().isPaused = true;
        fCon.GetComponent<FlowchartSequenceController>().isStarted = false;
        DM.ShowDialogue(IE[2].GetDialogue());
    }
}


