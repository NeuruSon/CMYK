﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class SaveCheckController : MonoBehaviour
{
    List<bool> isSaveSlotFilled;
    public TextMeshProUGUI reAskTmp, deletedTmp, startTmp;
    string reAskText, deletedText, startText;
    GameObject soundBox, sCon;
    GameObject conBtn, deleted_panel, deleteSaveSlot_panel, saveSlot, askStart_panel, loading_panel;
    bool isContinue = false;

    string savePath = "/Users/tarrtarr/Desktop/programming/Unity/CMYK/RETURN_in_a_while/Saves";

    void Start()
    {
        //player num: 1-3
        isSaveSlotFilled = new List<bool>();
        reAskText = reAskTmp.text;
        deletedText = deletedTmp.text;
        startText = startTmp.text;
        soundBox = GameObject.Find("soundBox");
        sCon = GameObject.Find("SceneController");
        conBtn = GameObject.Find("ContinueBtn");
        loading_panel = GameObject.Find("loading_panel");
        loading_panel.SetActive(false);
        askStart_panel = GameObject.Find("askStart_panel");
        askStart_panel.SetActive(false);
        deleted_panel = GameObject.Find("deleted_panel");
        deleted_panel.SetActive(false);
        deleteSaveSlot_panel = GameObject.Find("deleteSaveSlot_panel");
        deleteSaveSlot_panel.SetActive(false);
        saveSlot = GameObject.Find("SaveSlot");
        saveSlot.SetActive(false);

        for (int i = 1; i <= 3; ++i)
        {
            isSaveSlotFilled.Add(File.Exists(savePath + "/p" + i + ".sav"));
        }

        if (!isSaveSlotFilled.Contains(true))
        {
            conBtn.GetComponent<Button>().interactable = false;
        }
        else
        {
            conBtn.GetComponent<Button>().interactable = true;
        }
    }

    void Update()
    {
        
    }

    public void setSaveSlotInfo(int playerNum)
    {
        Debug.Log(playerNum);
        if (File.Exists(savePath + "/p" + playerNum + ".sav"))
        {
            isSaveSlotFilled[playerNum - 1] = true;
            GameObject.Find("Slot" + playerNum + "_Btn").GetComponent<Button>().interactable = true;
            GameObject.Find("Slot" + playerNum + "_DeleteBtn").GetComponent<Button>().interactable = true;
            GameObject.Find("slot" + playerNum + "_tmp").GetComponent<TextMeshProUGUI>().text = SaveController.getName(playerNum) + "의 모험\n어디까지 했더라?";
        }
        else
        {
            isSaveSlotFilled[playerNum - 1] = false;
            if (isContinue)
            {
                GameObject.Find("Slot" + playerNum + "_Btn").GetComponent<Button>().interactable = false;
                GameObject.Find("Slot" + playerNum + "_DeleteBtn").GetComponent<Button>().interactable = false;
            }
            else
            {
                GameObject.Find("Slot" + playerNum + "_Btn").gameObject.GetComponent<Button>().interactable = true;
                GameObject.Find("Slot" + playerNum + "_DeleteBtn").gameObject.GetComponent<Button>().interactable = false;
            }
            GameObject.Find("slot" + playerNum + "_tmp").GetComponent<TextMeshProUGUI>().text = "* 아직 모험이 기록되지 않았어요";
        }
    }

    public void askDeleteSaveSlot(int playerNum)
    {
        reAskTmp.text = playerNum + reAskText;
        PlayData.curSaveSlotNum = playerNum;
        deleteSaveSlot_panel.SetActive(true);
    }

    public void deleteSaveSlot()
    {
        int playerNum = PlayData.curSaveSlotNum;
        SaveController.deleteDatas(playerNum);
        deleted_panel.gameObject.SetActive(true);
        deletedTmp.text = playerNum + deletedText;
        StartCoroutine(waitForDisappear(playerNum));
    }

    public void cancelDeleteSaveSlot()
    {
        reAskTmp.text = reAskText;
        deleteSaveSlot_panel.gameObject.SetActive(false);
        PlayData.curSaveSlotNum = 0;
    }

    IEnumerator waitForDisappear(int playerNum)
    {
        soundBox.GetComponent<GameSubSoundController>().on_effectSFX();
        setSaveSlotInfo(playerNum);
        yield return new WaitForSeconds(3f);
        deletedTmp.text = deletedText;
        deleted_panel.gameObject.SetActive(false);
        cancelDeleteSaveSlot();
        bool continueFlag = isSaveSlotFilled.Contains(true);
        conBtn.GetComponent<Button>().interactable = continueFlag;
        saveSlot.SetActive(continueFlag);
    }

    public void setAllSlotsInfo()
    {
        for (int i = 1; i <= 3; ++i)
        {
            setSaveSlotInfo(i);
        }
    }

    public void continueBtn()
    {
        isContinue = true;
        saveSlot.gameObject.SetActive(true);
        setAllSlotsInfo();
    }

    public void newBtn()
    {
        isContinue = false;
        saveSlot.gameObject.SetActive(true);
        setAllSlotsInfo();
    }

    public void startGame(int playerNum)
    {
        if (isContinue)
        {
            loading_panel.SetActive(true);
            SaveController.loadDatas(playerNum).setData();
            sCon.GetComponent<SceneController>().toScene(PlayData.currentSceneName);
        }
        else
        {
            askNewGame(playerNum);
        }
    }

    public void askNewGame(int playerNum)
    {
        PlayData.curSaveSlotNum = playerNum;
        soundBox.GetComponent<GameSubSoundController>().on_effectSFX();
        askStart_panel.gameObject.SetActive(true);
        string num = "?";
        switch (playerNum)
        {
            case 1:
                num = "첫";
                break;
            case 2:
                num = "두";
                break;
            case 3:
                num = "세";
                break;
        }
        startTmp.text = num + startText;
    }

    public void cancelNewGame()
    {
        PlayData.curSaveSlotNum = 0;
        askStart_panel.gameObject.SetActive(false);
    }

    public void acceptedNewGame()
    {
        loading_panel.SetActive(true);
        sCon.GetComponent<SceneController>().toVillageYScene();
    }
}
