using System.Collections;
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
    string savePath = System.IO.Directory.GetCurrentDirectory() + "/Resources";

    //string savePath = Application.dataPath + "/Resources";

    void Start()
    {
#if UNITY_EDITOR_OSX
        savePath = System.IO.Directory.GetCurrentDirectory() + "/Assets/Resources/Saves";
        Debug.Log("E_OSX_" + savePath);
#elif UNITY_EDITOR_64
        savePath = System.IO.Directory.GetCurrentDirectory() + "/Assets/Resources/Saves";
        Debug.Log("E_WIN_" + savePath);
#elif UNITY_STANDALONE_OSX
        savePath = System.IO.Directory.GetCurrentDirectory() + "/RETURN_in_a_while_Data/Resources";
        Debug.Log("S_OSX_" + savePath);
#elif UNITY_STANDALONE_WIN
        savePath = System.IO.Directory.GetCurrentDirectory() + "/RETURN_in_a_while_Data/Resources";
        Debug.Log("S_WIN_" + savePath);
#endif

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
            GameObject.Find("slot" + playerNum + "_tmp").GetComponent<TextMeshProUGUI>().text = SaveController.getName(playerNum) + "의 모험\n" + printChapter_subtitle(SaveController.getCurSceneName(playerNum));
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
            Debug.Log(playerNum);
            SaveController.setData(playerNum);
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

    public string printChapter_subtitle(string currentSceneName)
    {
        switch(currentSceneName)
        {
            case "Ch00_Title":
                return "error_title";
            case "Ch01_InTowerY":
                return "챕터1: 모험의 시작에 불을 지피자";
            case "Ch01_Yvillage":
                return "챕터1: 여기는 어디?";
            case "Ch02_Ccave":
                return "챕터2: 우연히 찾은 지름길";
            case "Ch02_gotoC":
                return "챕터2: C탑을 향한 여정";
            case "Ch02_InTowerC":
                return "챕터2: C탑의 가디언, 두(DO)";
            case "Ch03_CVillage":
                return "챕터3: 장인 배만드라를 찾아서";
            case "Ch03_InTowerM":
                return "챕터3: M탑의 가디언, 고투(GOTO)";
            case "Ch03_Kkaebu":
                return "챕터3: 깨부를 구하기 위해";
            case "Ch04_InTowerK":
                return "챕터4: K탑의 가디언, 그리고 마왕, 브레이크(BREAK)";
            case "Ch05_Ending":
                return "error_ending";
        }

        return "N/A";
    }
}
