using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public GameObject UI; //유니티 에디터에서 지정하는 옵션 
    bool active = false; 

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


