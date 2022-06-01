using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveController
{
    static string savePath = "/Users/tarrtarr/Desktop/programming/Unity/CMYK/RETURN_in_a_while/Saves";
    public static void saveDatas(int playerNum)
    {
        BinaryFormatter formatter = new BinaryFormatter(); //이진 변환 객체 생성 
        FileStream streamer = new FileStream(savePath + "/p"+ playerNum + ".sav", FileMode.Create); //파일 입출력 객체 생성. 파일 생성 
        PlayerData data = new PlayerData(); //데이터 객체 생성 
        formatter.Serialize(streamer, data); //이진화 
        streamer.Close(); //파일 변환 종료 
    }
     
    public static PlayerData loadDatas(int playerNum) 
    {
        if (File.Exists(savePath + "/p" + playerNum + ".sav")) //세이브 파일이 있으면 
        {
            BinaryFormatter formatter = new BinaryFormatter(); //이진 변환 객체 생성 
            FileStream streamer = new FileStream(savePath + "/p" + playerNum + ".sav", FileMode.Open); //파일 열기 
            PlayerData data = formatter.Deserialize(streamer) as PlayerData; //해석해서 데이터 값으로 assign해줌 
            streamer.Close(); //파일 입출력 종료
            return data; //데이터 값 반환 
        }

        //saveDatas(playerNum); //없으면 만들기 
        return null; //아무것도 반환하지 않음 
    }

    public static void deleteDatas(int playerNum)
    {
        if (File.Exists(savePath + "/p" + playerNum + ".sav")) //세이브 파일이 있으면 
        {
            string path = savePath + "/p" + playerNum + ".sav";
            FileInfo fileInfo = new FileInfo(path);
            fileInfo.Delete(); //지운다.
            loadDatas(playerNum);
        }
    }

    public static string getName(int playerNum)
    {
        if (File.Exists(savePath + "/p" + playerNum + ".sav")) //세이브 파일이 있으면 
        {
            BinaryFormatter formatter = new BinaryFormatter(); //이진 변환 객체 생성 
            FileStream streamer = new FileStream(savePath + "/p" + playerNum + ".sav", FileMode.Open); //파일 열기 
            PlayerData data = formatter.Deserialize(streamer) as PlayerData; //해석해서 데이터 값으로 assign해줌 
            streamer.Close(); //파일 입출력 종료
            return data.getName(); //데이터 값 반환 
        }

        //saveDatas(playerNum); //없으면 만들기 
        return "N/A"; 
    }
}

[Serializable]
public class PlayerData : object
{
    int _curSaveSlotNum = 0;

    string _playerName = "용사"; 
    int[] _isPuzzleCleared = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    int _p3 = 0;
    bool[] _isFlowchartCleared = new bool[6] { false, false, false, false, false, false };

    //for save
    string _currentSceneName = "";

    //settings
    float _curBrightness = 1.0f;
    float _curBgmVolume = 0.5f;
    float _curSfxVolume = 0.6f;

    //in-game variables
    bool _toPreScene = false;
    string _preSceneName = "";
    string _puzzleName = "";
    float _preSceneLocation_x = 0f;
    float _preSceneLocation_y = 0f;
    float _preSceneLocation_z = 0f;
    float _preSceneRotation_x = 0f;
    float _preSceneRotation_y = 0f;
    float _preSceneRotation_z = 0f;

    public PlayerData()
    {
        _curSaveSlotNum = PlayData.curSaveSlotNum;
        _playerName = PlayData.playerName;
        _isPuzzleCleared = PlayData.isPuzzleCleared;
        _p3 = PlayData.p3;
        _isFlowchartCleared = PlayData.isFlowchartCleared;
        _currentSceneName = PlayData.currentSceneName;
        _curBrightness = PlayData.curBrightness;
        _curBgmVolume = PlayData.curBgmVolume;
        _curSfxVolume = PlayData.curSfxVolume;
        _toPreScene = PlayData.toPreScene;
        _preSceneName = PlayData.preSceneName;
        _puzzleName = PlayData.puzzleName;
        _preSceneLocation_x = PlayData.preSceneLocation.x;
        _preSceneLocation_y = PlayData.preSceneLocation.y;
        _preSceneLocation_z = PlayData.preSceneLocation.z;
        _preSceneRotation_x = PlayData.preSceneRotation.x;
        _preSceneRotation_y = PlayData.preSceneRotation.y;
        _preSceneRotation_z = PlayData.preSceneRotation.z;
    }

    public void setData()
    {
        PlayData.curSaveSlotNum = _curSaveSlotNum;
        PlayData.playerName = _playerName;
        PlayData.isPuzzleCleared = _isPuzzleCleared;
        PlayData.p3 = _p3;
        PlayData.isFlowchartCleared = _isFlowchartCleared;
        PlayData.currentSceneName = _currentSceneName;
        PlayData.curBrightness = _curBrightness;
        PlayData.curBgmVolume = _curBgmVolume;
        PlayData.curSfxVolume = _curSfxVolume;
        PlayData.toPreScene = _toPreScene;
        PlayData.preSceneName = _preSceneName;
        PlayData.preSceneLocation.x = _preSceneLocation_x;
        PlayData.preSceneLocation.y = _preSceneLocation_y;
        PlayData.preSceneLocation.z = _preSceneLocation_z;
        PlayData.preSceneRotation.x = _preSceneRotation_x;
        PlayData.preSceneRotation.y = _preSceneRotation_y;
        PlayData.preSceneRotation.z = _preSceneRotation_z;
    }

    public string getName()
    {
        return _playerName;
    }
}