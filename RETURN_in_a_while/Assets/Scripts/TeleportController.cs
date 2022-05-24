using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    GameObject pCon, cCon;
    int index = 0;
    public Vector3[] dest_position;
    public Vector3[] dest_rotation;

    void Awake()
    {
        pCon = GameObject.Find("Player");
        cCon = GameObject.Find("Continue");
    }

    [System.Obsolete]
    private void OnEnable()
    {
        pCon.GetComponent<Transform>().transform.localPosition = dest_position[index];
        int childCount = pCon.transform.GetChildCount();
        for (int i = 0; i < childCount; ++i)
        {
            pCon.transform.GetChild(i).GetComponent<Transform>().transform.localEulerAngles = dest_rotation[index];
        }

        cCon.GetComponent<Transform>().transform.localPosition = dest_position[index] + cCon.GetComponent<ContinueController>().offset;
        ++index;
        gameObject.SetActive(false);
    }
}
