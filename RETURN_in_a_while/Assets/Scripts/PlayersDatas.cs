using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayData : PlayerData //저장해야 할 데이터 목록 
{
    public static int curSaveSlotNum = 0;

    public static string playerName = "용사";

    //퍼즐 진행상태; 음수: 오답 횟수 /0: 미진행 /1: 클리어 
    public static int[] isPuzzleCleared = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int p3 = 0;
    public static bool[] isFlowchartCleared = new bool[6] { false, false, false, false, false, false };

    //for save
    public static string currentSceneName = "";

    //settings
    public static float curBrightness = 1.0f;
    public static float curBgmVolume = 0.5f;
    public static float curSfxVolume = 0.6f;

    //in-game variables
    public static bool toPreScene = false;
    public static string preSceneName = "";
    public static string puzzleName = ""; //오픈할 퍼즐 이름 전역 static 파라미터로 받아 적용 -> 씬을 이동해도 임시 데이터로서 작동함. 
    public static Vector3 preSceneLocation = new Vector3(24, 20, 14); //씬 교체 시 기존 위치를 저장하고 복귀할 때 사용.
    public static Vector3 preSceneRotation = new Vector3(0, 0, 0); //씬 교체 시 기존 각도를 저장하고 복귀할 때 사용.
}