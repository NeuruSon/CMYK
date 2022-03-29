using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowchartLine : MonoBehaviour
{
    public string decision = "n/a"; //해당 화살표의 의미
    public int curve = -1; //꺾이는 횟수(0~2)
    public int line_size = 3;
    RectTransform line1, line2, line3; //선
    RectTransform triangle; //삼각형 
    public GameObject start, end; //시작 블록과 종료 블록
    public int start_point = -1, end_point = -1; //시작 블록과 종료 블록의 연결 위치
    public float double_curve_offset = 30f;

    public RectTransform test_start, test_end;

    void Start()
    {
        line1 = gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        line2 = gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        line3 = gameObject.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
        triangle = gameObject.transform.GetChild(3).gameObject.GetComponent<RectTransform>();

        line1.sizeDelta = new Vector2(0, 0);
        line2.sizeDelta = new Vector2(0, 0);
        line3.sizeDelta = new Vector2(0, 0);

        //시작과 끝 블록이 처음부터 설정되어 있고, 꺾임 값이 제대로 들어있는 경우
        if (start && end && curve >= 0 && start_point > -1 && end_point > -1)
        {
            createLine(curve, start, end, decision, start_point, end_point);
        }
        else if (start && end && curve >= 0)
        {
            createLine(curve, start, end, decision);
        }
    }

    void Update()
    {

    }

    public void createLine(int _curve, GameObject _start, GameObject _end, string _decision, int p_start = -1, int p_end = -1)
    {
        RectTransform t_start, t_end;
        float w_start, h_start, w_end, h_end; //시작 블록과 종료 블록의 너비와 높이

        //시작 블록과 종료 블록의 상하좌우 좌표
        Vector3[] m_start = new Vector3[4];
        Vector3[] m_end = new Vector3[4];

        t_start = _start.GetComponent<RectTransform>();
        t_end = _end.GetComponent<RectTransform>();

        w_start = t_start.rect.width / 2;
        h_start = t_start.rect.height / 2;
        w_end = t_end.rect.width / 2;
        h_end = t_end.rect.height / 2;

        m_start[0] = t_start.anchoredPosition + new Vector2(0, h_start);
        m_start[1] = t_start.anchoredPosition - new Vector2(w_start, 0);
        m_start[2] = t_start.anchoredPosition - new Vector2(0, h_start);
        m_start[3] = t_start.anchoredPosition + new Vector2(w_start, 0);

        m_end[0] = t_end.anchoredPosition + new Vector2(0, h_end);
        m_end[1] = t_end.anchoredPosition - new Vector2(w_end, 0);
        m_end[2] = t_end.anchoredPosition - new Vector2(0, h_end);
        m_end[3] = t_end.anchoredPosition + new Vector2(w_end, 0);

        int short_start = p_start, short_end = p_end;
        float sqr_short_dist = 0f;

        //서로 가장 가까운 중점을 찾는다 
        if (short_start < 0 && short_end < 0)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    Vector3 offset = m_start[i] - m_end[j];
                    float sqrLen = offset.sqrMagnitude;

                    if (sqr_short_dist == 0f || sqr_short_dist > sqrLen)
                    {
                        short_start = i; short_end = j;
                        sqr_short_dist = sqrLen;
                    }
                }
            }
        }

        test_start.anchoredPosition = m_start[short_start];
        test_end.anchoredPosition = m_end[short_end];

        if (_curve == 0)
        {
            Vector3 offset = m_start[short_start] - m_end[short_end];
            float _x = Mathf.Abs(offset.x), _y = Mathf.Abs(offset.y);
            if (_x > 0 && _y <= 0)
            {
                line1.sizeDelta = new Vector2(_x, line_size);
                //선 설치
                triangle.localRotation = Quaternion.Euler(0, 0, 90);
                //삼각형 설치
            }
            else if (_y > 0 && _x <= 0)
            {
                line1.sizeDelta = new Vector2(line_size, _y);
                line1.localRotation = Quaternion.Euler(0, 0, -90);
                //선 설치
                //삼각형 설치
            }
            else { Debug.Log("both are under 0 or above 0"); }
        }
        else if (_curve == 1)
        {
            Vector3 offset = m_start[short_start] - m_end[short_end];
            float _x = Mathf.Abs(offset.x), _y = Mathf.Abs(offset.y);

            line1.sizeDelta = new Vector2(_x + line_size, line_size);
            line2.sizeDelta = new Vector2(line_size, _y);
            if (short_start == 1 || short_start == 3)
            {
                //선1 설치
                line1.localPosition = m_start[short_start] - new Vector3(line_size, 0);
                //선2 설치
                line2.localPosition = new Vector2(m_start[short_start].x + _x, m_start[short_start].y);
                //삼각형 설치
                triangle.localPosition = m_end[short_end];
            }
            else
            {
                //선2 설치
                //선1 설치
                //삼각형 90도 돌려서 설치 
            }
        }
        else if (_curve == 2)
        {
            Vector3 offset = m_start[short_start] - m_end[short_end];
            float _x = Mathf.Abs(offset.x), _y = Mathf.Abs(offset.y);
            
            if (offset.x > 0)
            {
                line1.sizeDelta = new Vector2(_x + double_curve_offset, line_size);
                line3.sizeDelta = new Vector2(_x, line_size);
                line2.sizeDelta = new Vector2(line_size, _y);
                //선 모두 설치
                //삼각형 -90도 돌려서 설치 
            }
            else
            {
                line1.sizeDelta = new Vector2(_x, line_size);
                line3.sizeDelta = new Vector2(_x + double_curve_offset, line_size);
                line2.sizeDelta = new Vector2(line_size, _y);
                //선 모두 설치
                //삼각형 -90도 돌려서 설치 
            }
        }
    }

    public void deleteLine()
    {
        Destroy(this.gameObject);
    }
}
