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
        pCon = GameObject.Find("Hero");
        cCon = GameObject.Find("Continue");
    }

    private void OnEnable()
    {
        pCon.GetComponent<Transform>().transform.localPosition = dest_position[index];
        pCon.GetComponent<Transform>().transform.localRotation = Quaternion.Euler(dest_rotation[index]);
        cCon.GetComponent<Transform>().transform.localPosition = dest_position[index] + cCon.GetComponent<ContinueController>().offset;
        ++index;
        gameObject.SetActive(false);
    }
}
