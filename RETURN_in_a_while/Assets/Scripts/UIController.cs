using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public GameObject UI;
    public bool active = false;

    private void Start()
    {
    }

    public void OpenUI()
    {
        UI.SetActive(true);
    }

    public void CloseUI()
    {
        UI.SetActive(false);
    }


    public void OpenAndCloseUI()
    {

        if (active == true)
        {

            UI.SetActive(false);
            active = false;
            
        }
        else 
        {
            UI.SetActive(true);
            active = true;
            
        }

    }
}


