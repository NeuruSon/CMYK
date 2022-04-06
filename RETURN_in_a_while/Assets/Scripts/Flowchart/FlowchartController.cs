using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlowchartController : MonoBehaviour
{
    public static bool isFlowchartOn = true; //실제 게임에서는 기본값 false 
    public bool isSelectMode = false; 
    public GameObject selectPanel, selectBackPanel, FlowchartUI;
    GameObject gCon;

    public GameObject start, end;
    public GameObject wrongLine, rightLine;
    public string startKey, endKey;

    bool isGrowing = true;
    float scaleSpd = 0.0015f;

    void Start()
    {
        gCon = GameObject.Find("GameController");
    }

    void Update()
    {
        if (isFlowchartOn)
        {
            //if (isGrowing == true && c_line.GetComponent<RectTransform>().localScale.x >= 1.1f && c_line.GetComponent<RectTransform>().localScale.y >= 1.1f)
            //{
            //    isGrowing = false;
            //}
            //else if (isGrowing == true && c_line.GetComponent<RectTransform>().localScale.x < 1.1f && c_line.GetComponent<RectTransform>().localScale.y < 1.1f)
            //{
            //    c_line.GetComponent<RectTransform>().localScale += new Vector3(scaleSpd, scaleSpd);
            //}
            //else if (isGrowing == false && c_line.GetComponent<RectTransform>().localScale.x <= 1.0f && c_line.GetComponent<RectTransform>().localScale.y <= 1.0f)
            //{
            //    isGrowing = true;
            //}
            //else
            //{
            //    c_line.GetComponent<RectTransform>().localScale -= new Vector3(scaleSpd, scaleSpd);
            //}
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
                //wrongLine.GetComponent<FlowchartLineController>().resetParent();
                wrongLine.SetActive(false);
                rightLine.SetActive(true);
                start.GetComponent<FlowchartShapeController>().resetParent();
                end.GetComponent<FlowchartShapeController>().resetParent();
                //rightLine.GetComponent<FlowchartLineController>().setParent();
                isFlowchartOn = false;
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
