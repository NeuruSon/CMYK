using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    GameObject sCon, gCon, pCon, fCon;
    bool isActive = false;
    //public int npcNum; //유니티 에디터에서 지정하는 옵션 
    public GameObject quad; //유니티 에디터에서 지정하는 옵션 
    public GameObject flowchart; //유니티 에디터에서 지정하는 옵션


    void Awake()
    {
        sCon = GameObject.Find("SceneController");
        gCon = GameObject.Find("GameController");
        pCon = GameObject.Find("Player");
        fCon = GameObject.Find("FlowchartController");
    }

    void Update()
    {
        if (isActive == true)
        {
            quad.SetActive(true);
        }
        else if (isActive != true)
        {
            quad.SetActive(false);
        }

        if (isActive == true && Input.GetKeyDown(KeyCode.E))
        {
            flowchart.SetActive(true);
            FlowchartController.isFlowchartOn = true;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            isActive = false;
        }
    }
}
