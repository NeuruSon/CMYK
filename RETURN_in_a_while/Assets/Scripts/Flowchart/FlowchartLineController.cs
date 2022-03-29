using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FlowchartLineController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    SpriteRenderer sprite;
    GameObject fCon, parent;

    bool isGrowing = false;
    float scaleSpd = 0.002f;


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
        fCon.GetComponent<FlowchartController>().isSelectMode = true;
        setParent();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("down");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
        isGrowing = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exit");
        isGrowing = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("up");
    }

    void Start()
    {
        fCon = GameObject.Find("FlowchartController");
        parent = transform.parent.gameObject;
    }

    void Update()
    {
        if (fCon.GetComponent<FlowchartController>().isSelectMode == true)
        {
            Debug.Log("1");
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        }
        else if (isGrowing == true && gameObject.GetComponent<RectTransform>().localScale.x < 1.1f && gameObject.GetComponent<RectTransform>().localScale.y < 1.1f)
        {
            Debug.Log("2");
            gameObject.GetComponent<RectTransform>().localScale += new Vector3(scaleSpd, scaleSpd);
        }
        else if (isGrowing == false && gameObject.GetComponent<RectTransform>().localScale.x >= 1.0f && gameObject.GetComponent<RectTransform>().localScale.y >= 1.0f)
        {
            gameObject.GetComponent<RectTransform>().localScale -= new Vector3(scaleSpd, scaleSpd);
        }
        else
        {
            //Debug.Log("4");
            
        }
    }

    public void setParent()
    {
        transform.SetParent(fCon.GetComponent<FlowchartController>().selectPanel.transform);
    }

    public void resetParent()
    {
        transform.SetParent(parent.transform);
    }
}