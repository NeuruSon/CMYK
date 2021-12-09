using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayData //저장해야 할 데이터 목록 
{
    public static string puzzleName = ""; //오픈할 퍼즐 이름 전역 static 파라미터로 받아 적용 -> 씬을 이동해도 임시 데이터로서 작동함 
    public static Vector3 preSceneLocation = new Vector3(24, 12, 14); //씬 교체 시 기존 위치를 저장하고 복귀할 때 사용. 

    protected PlayData() { }

}

public class PlayerDatas_p1 : PlayData
{
    bool isCleared = false;
}

public static class PlayersDatas //n개 슬롯에 맞춘 모든 플레이어의 정보를 담는 배열 
{
    static PlayData[] playersDatas;
}