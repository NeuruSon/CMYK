using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleController_Puzzle6_switch : MonoBehaviour
{
    public GameObject hole1, hole2, hole3, hole4, hole5, stone1, stone2, stone3, stone4, stone5;
    public TMP_Dropdown num_drd, order_drd;
    GameObject[] holes = new GameObject[5];
    GameObject[] stones = new GameObject[5];
    int[] placed = new int[5] { -1, -1, -1, -1, -1 };
    Vector3[] origin = new Vector3[5];

    void Start()
    {
        holes[0] = hole1;
        holes[1] = hole2;
        holes[2] = hole3;
        holes[3] = hole4;
        holes[4] = hole5;

        stones[0] = stone1;
        stones[1] = stone2;
        stones[2] = stone3;
        stones[3] = stone4;
        stones[4] = stone5;

        origin[0] = stone1.transform.localPosition;
        origin[1] = stone2.transform.localPosition;
        origin[2] = stone3.transform.localPosition;
        origin[3] = stone4.transform.localPosition;
        origin[4] = stone5.transform.localPosition;
    }

    void Update()
    {
        
    }

    public void clicked()
    {
        int num = num_drd.value;
        int order = order_drd.value;
        for (int i = 0; i < 5; ++i)
        {
            if (placed[i] == num)
            {
                stones[num].tag = "false";
                placed[i] = -1;
                stones[num].transform.localPosition = origin[num];
            }
        }

        if (placed[order] < 0)
        {
            stones[num].tag = "true";
            placed[order] = num;
            stones[num].transform.localPosition = holes[order].transform.localPosition;
        }
        else
        {
            stones[placed[order]].tag = "false";
            stones[placed[order]].transform.localPosition = origin[placed[order]];
            stones[num].tag = "true";
            placed[order] = num;
            stones[num].transform.localPosition = holes[order].transform.localPosition;
        }
        Debug.Log(placed[0] + "" + placed[1] + "" + placed[2] + "" + placed[3] + "" + placed[4]);
    }
}
