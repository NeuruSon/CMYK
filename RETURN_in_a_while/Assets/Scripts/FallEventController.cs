using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEventController : MonoBehaviour
{
    GameObject sCon, pCon;

    void Start()
    {
        sCon = GameObject.Find("SceneController");
        pCon = GameObject.Find("Player");
    }

    void Update()
    {
    }

    public void falling()
    {
        pCon.GetComponent<Transform>().transform.localPosition = new Vector3(262, 110, 88); //player를 이전 씬과 동일하게 배치
        int childCount = pCon.transform.childCount;
        for (int i = 0; i < childCount; ++i)
        {
            pCon.transform.GetChild(i).GetComponent<Transform>().transform.localEulerAngles = new Vector3(0, -8, 0); //player를 이전 씬과 동일하게 배치
        }
    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.CompareTag("Player"))
    //    {
    //        pCon.GetComponent<Transform>().transform.localPosition = new Vector3(262, 110, 88); //player를 이전 씬과 동일하게 배치
    //        int childCount = pCon.transform.childCount;
    //        for (int i = 0; i < childCount; ++i)
    //        {
    //            pCon.transform.GetChild(i).GetComponent<Transform>().transform.localEulerAngles = new Vector3(0, -8, 0); //player를 이전 씬과 동일하게 배치
    //        }
    //    }
    //}
}