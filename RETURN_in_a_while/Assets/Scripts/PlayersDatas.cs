using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayData //저장해야 할 데이터 목록 
{
    bool isCleared = false; //맞았니?

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