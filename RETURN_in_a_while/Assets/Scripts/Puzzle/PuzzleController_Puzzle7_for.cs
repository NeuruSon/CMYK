using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Button = UnityEngine.UI.Button;

public class PuzzleController_Puzzle7_for : MonoBehaviour
{
    public GameObject t_repeatCount, for_panel, gCon, character; //횟수_tmp, panel
    public Sprite spr_tempBridge, spr_horizontal, spr_vertical, spr_unselected, spr_selected;
    Button selectedBtn;
    bool isPlacingMode = false, isMoving = false;
    public Button[,] buttons = new Button[11, 9];
    int[,] repeat = new int[11, 9];
    int repeatCount = 0;

    void Start()
    {
        for (int i = 0; i < 11; ++i)
        {
            for (int j = 0; j < 9; ++j) //array 특성으로 부득이하게 0부터 시작 
            {
                string s;
                if (i >= 10)
                {
                    s = "b_" + (j + 1).ToString();
                }
                else
                {
                    s = "b" + i.ToString() + (j + 1).ToString();
                }
                buttons[i, j] = GameObject.Find(s).gameObject.GetComponent<Button>() as Button;
                repeat[i, j] = 0;
                //buttons[i, j].GetComponent<Image>().sprite = spr_selected; //test, 정상 작동
            }
        }
    }

    void Update()
    {
    }

    public void clicked()
    {
        if (selectedBtn && selectedBtn.tag == "false")
        {
            selectedBtn.GetComponent<Image>().sprite = spr_unselected;
        }

        Button btn = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        if (btn.tag != "Untagged")
        {
            selectedBtn = btn;
            SpriteState spriteState = new SpriteState();
            spriteState = selectedBtn.spriteState;
        }

        if (selectedBtn.tag == "false" && !isPlacingMode)
        {
            selectedBtn.GetComponent<Image>().sprite = spr_selected;
            isPlacingMode = true;
            for_panel.SetActive(true);
        }
        else
        {
            selectedBtn.tag = "false";
            selectedBtn.GetComponent<Image>().sprite = spr_unselected;
            isPlacingMode = false;
            for_panel.SetActive(false);
        }
    }

    public void horizontal_bridge()
    {
        selectedBtn.tag = "horizontal";
        //selectedBtn.GetComponent<Image>().sprite = spr_tempBridge;
        selectedBtn.GetComponent<Image>().sprite = spr_horizontal;
        repeatCount = 1;
    }

    public void vertical_bridge()
    {
        selectedBtn.tag = "vertical";
        //selectedBtn.GetComponent<Image>().sprite = spr_tempBridge;
        selectedBtn.GetComponent<Image>().sprite = spr_vertical;
        repeatCount = 1;
    }

    public void plus()
    {
        if (selectedBtn.tag == "horizontal" || selectedBtn.tag == "vertical")
        {
            string s = selectedBtn.ToString();
            Debug.Log(s);
            int i = int.Parse(s.Substring(1, 1));
            int j = int.Parse(s.Substring(2, 1));
            Button btn = buttons[i, j];

            //선택된 버튼의 위치를 따짐 
            //다음 칸 속성(tag)을 따짐
            //반복 횟수를 저장하고 반복함 

            int repeatCount = int.Parse(t_repeatCount.GetComponent<TextMeshProUGUI>().text);
            if (repeatCount + 1 < 10)
            {
                ++repeatCount;
                t_repeatCount.GetComponent<TextMeshProUGUI>().text = repeatCount.ToString();
            }
            else
            {
                t_repeatCount.GetComponent<TextMeshProUGUI>().text = "9";
                Debug.Log("거 적당히 합시다");
            }
        }
        else
        {
            //다리 방향 먼저 선택해 주세요!
        }
    }

    public void minus()
    {
        if (selectedBtn.tag == "horizontal" || selectedBtn.tag == "vertical")
        {
            string s = selectedBtn.ToString();
            Debug.Log(s);
            int i = int.Parse(s.Substring(1, 1));
            int j = int.Parse(s.Substring(2, 1));
            Button btn = buttons[i, j];

            //선택된 버튼의 위치를 따짐 
            //다음 칸 속성(tag)을 따짐
            //반복 횟수를 저장하고 반복함 


            int repeatCount = int.Parse(t_repeatCount.GetComponent<TextMeshProUGUI>().text);
            if (repeatCount - 1 > 0)
            {
                --repeatCount;
                t_repeatCount.GetComponent<TextMeshProUGUI>().text = repeatCount.ToString();
            }
            else
            {
                t_repeatCount.GetComponent<TextMeshProUGUI>().text = "1";
                Debug.Log("거 적당히 합시다");
            }
        }
        else
        {
            //다리 방향 먼저 선택해 주세요!
        }
    }

    public void move()
    {
        Vector2 pos = new Vector2(0, 7); //cols는 부득이하게 -1 값으로 계산 
        character.transform.position = buttons[0, 7].transform.position;
        if (isMoving)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
            while (isMoving == true && pos != new Vector2(11, 2))
            {
                //StartCoroutine(WaitForASecond());

                if ((int)pos.x + 1 < 11 && (buttons[(int)pos.x + 1, (int)pos.y].tag == "horizontal"
                    || buttons[(int) pos.x + 1, (int) pos.y].tag == "vertical"
                    || buttons[(int)pos.x + 1, (int)pos.y].tag == "true"))
                {
                    ++pos.x;
                    character.transform.position = buttons[(int)pos.x, (int)pos.y].transform.position;
                }
                else if ((int)pos.y - 1 >= 0 && (buttons[(int)pos.x, (int)pos.y + 1].tag == "horizontal"
                    || buttons[(int)pos.x, (int)pos.y - 1].tag == "vertical"
                    || buttons[(int)pos.x, (int)pos.y - 1].tag == "true"))
                {
                    --pos.y;
                    character.transform.position = buttons[(int)pos.x, (int)pos.y].transform.position;
                }
                else
                {
                    break;
                }
            }
            isMoving = false;

            if (pos == new Vector2(11, 2))
            {
                Debug.Log("Congratulations!");
            }
            else
            {
                Debug.Log("Failed...");
            }
        }
    }

    //IEnumerator WaitForASecond()
    //{
    //    Debug.Log("wait");
    //    yield return new WaitForSeconds(1f);
    //}
}
