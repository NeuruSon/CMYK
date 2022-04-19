using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEventController : MonoBehaviour
{
    GameObject sCon;

    void Start()
    {
        sCon = GameObject.Find("SceneController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && sCon.GetComponent<SceneController>().getThisSceneName() == "gotoC")
        {
            sCon.GetComponent<SceneController>().toCaveScene();
        }
        else if (gameObject.name == "light" && col.tag == "Player" && sCon.GetComponent<SceneController>().getThisSceneName() == "Cave")
        {
            sCon.GetComponent<SceneController>().toTowerCScene();
        }
        else if (gameObject.name == "fall" && col.tag == "Player" && sCon.GetComponent<SceneController>().getThisSceneName() == "Cave")
        {
            sCon.GetComponent<SceneController>().toCaveScene();
        }
    }
}
