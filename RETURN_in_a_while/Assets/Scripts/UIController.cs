using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public GameObject UI;
    public bool active = false;
    Button soundbtn; // display 버튼 클릭시 아래로 이동
    Button displaybtn;

    private void Start()
    {
        soundbtn = GameObject.Find("SoundSettings").GetComponent<Button>();
        displaybtn = GameObject.Find("DisplaySettings").GetComponent<Button>();
    }

    public void OpenUI()
    {

        UI.SetActive(true);

    }

    public void CloseUI()
    {
        UI.SetActive(false);
    }

    public void displayOpenAndCloseUI()
    {

        if (active == true)
        {
            soundbtn.transform.Translate(0, 300, 0);
            UI.SetActive(false);
            active = false;
            return;
        }
        if (active == false)
        {
            soundbtn.transform.Translate(0, -300, 0);
            UI.SetActive(true);
            active = true;
            return;
        }

    }
    public void OpenAndCloseUI()
    {

        if (active == true)
        {

            UI.SetActive(false);
            active = false;
            return;
        }
        if (active == false)
        {
            UI.SetActive(true);
            active = true;
            return;
        }

    }
}


