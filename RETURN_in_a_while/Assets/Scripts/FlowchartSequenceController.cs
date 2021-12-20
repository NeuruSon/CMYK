using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowchartSequenceController : MonoBehaviour
{
    public bool isStarted = false;
    public List<Image> flowchart;
    float speed = 1.0f, waitTime = 1.0f;
    int i = 0;

    void Start()
    {
        isStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            if (flowchart[i].fillAmount < 1)
            {
                flowchart[i].fillAmount += speed / waitTime * Time.deltaTime;
            }
            else if (flowchart[i].fillAmount >= 1 && i + 1 < flowchart.Count)
            {
                ++i;
            }
        }
    }
}
