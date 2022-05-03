using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NamingController : MonoBehaviour
{
    public bool isNaming = false, isWriting = false, isChecking = false;
    public GameObject namingPanel, checkPanel, nameTmp;
    public TMP_InputField namingField;

    void Update()
    {
        if (isNaming)
        {
            namingPanel.SetActive(true);
            isWriting = true;

            if (isWriting)
            {
                namingField.characterLimit = 6;
                namingField.interactable = true;
            }

            if (isChecking)
            {
                checkPanel.SetActive(true);
                nameTmp.GetComponent<TextMeshProUGUI>().text = PlayData.playerName;
            }
            else
            {
                checkPanel.SetActive(false);
                isWriting = true;
            }
        }
        else
        {
            isWriting = false;
            isChecking = false;
            checkPanel.SetActive(false);
            namingField.interactable = false;
            namingPanel.SetActive(false);
        }
    }

    public void doneBtn()
    {
        PlayData.playerName = namingField.text;
        isWriting = false;
        isChecking = true;
    }

    public void backBtn()
    {
        PlayData.playerName = "";
        nameTmp.GetComponent<TextMeshProUGUI>().text = "";
        isChecking = false;
    }

    public void yesBtn()
    {
        isNaming = false;
        //fin
    }
}
