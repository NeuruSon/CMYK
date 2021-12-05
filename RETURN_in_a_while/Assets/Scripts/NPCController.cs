using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject quad;
    GameObject sCon, gCon;
    bool isActive = false;

    void Awake()
    {
        sCon = GameObject.Find("SceneController");
        gCon = GameObject.Find("GameController");
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
            sCon.GetComponentInChildren<SceneController>().toPuzzleScene();
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
