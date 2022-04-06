using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlowchartController : MonoBehaviour
{
    public static bool isFlowchartOn = false; //실제 게임에서는 기본값 false 
    public bool isSelectMode = false;
    public GameObject selectPanel, selectBackPanel, FlowchartUI;
    GameObject gCon;

    public GameObject start, end;
    public GameObject wrongLine, rightLine;
    public string startKey, endKey;

    void Start()
    {
        gCon = GameObject.Find("GameController");
    }

    void Update()
    {
        if (isFlowchartOn)
        {
            gCon.GetComponent<GameController>().isPaused = true;

            if (isSelectMode)
            {
                if (selectPanel.transform.childCount == 3)
                {
                    start = selectPanel.transform.GetChild(2).gameObject;
                }
                else if (selectPanel.transform.childCount == 4)
                {
                    end = selectPanel.transform.GetChild(3).gameObject;
                }

                selectPanel.SetActive(true);
                selectBackPanel.SetActive(true);
                
            }
            else
            {
                selectPanel.SetActive(false);
                selectBackPanel.SetActive(false);
            }

            answerCheck();
        }
        else
        {
            gCon.GetComponent<GameController>().isPaused = false;
            selectPanel.SetActive(false);
            selectBackPanel.SetActive(false);
        }
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    if (eventData.pointerClick.tag != "block")
    //    {
    //        isSelectMode = false;
    //    }
    //}

    void answerCheck()
    {
        if (start && end)
        {
            if (start.name == startKey && end.name == endKey)
            {
                wrongLine.SetActive(false);
                rightLine.SetActive(true);
            }
            else
            {
                start.GetComponent<FlowchartShapeController>().resetParent();
                end.GetComponent<FlowchartShapeController>().resetParent();
                start = null; end = null;
            }
        }
    }
}
