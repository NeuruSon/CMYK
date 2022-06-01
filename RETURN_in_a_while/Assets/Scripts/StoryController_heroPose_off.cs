using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController_heroPose_off : MonoBehaviour
{
    GameObject pCon;
    // Start is called before the first frame update
    void Start()
    {
        pCon = GameObject.Find("Hero");
        pCon.GetComponent<Animator>().SetInteger("doya", 0);
    }
}
