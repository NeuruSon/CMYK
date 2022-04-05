using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FlowchartShapeController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    SpriteRenderer sprite;
    GameObject fCon, parent;
    bool isItIn = false, isGrowing = false;
    float scaleSpd = 0.003f;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
        if (fCon.GetComponent<FlowchartController>().isSelectMode && !isItIn)
        {
            setParent();
        }
        else if (fCon.GetComponent<FlowchartController>().isSelectMode && isItIn)
        {
            resetParent();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
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
        Debug.Log("up");
    }

    void OnMouseOver()
    {
        Debug.Log("true");
        isGrowing = true;
    }

    void OnMouseExit()
    {
        isGrowing = false;
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
            if (isGrowing == true && gameObject.GetComponent<RectTransform>().localScale.x >= 1.1f && gameObject.GetComponent<RectTransform>().localScale.y >= 1.1f)
            {
                Debug.Log("1");
            }
            else if (isGrowing == true && gameObject.GetComponent<RectTransform>().localScale.x < 1.1f && gameObject.GetComponent<RectTransform>().localScale.y < 1.1f)
            {
                Debug.Log("2");
                gameObject.GetComponent<RectTransform>().localScale += new Vector3(scaleSpd, scaleSpd);
            }
            else if (isGrowing == false && gameObject.GetComponent<RectTransform>().localScale.x <= 1.0f && gameObject.GetComponent<RectTransform>().localScale.y <= 1.0f)
            {
                //Debug.Log("3");
            }
            else
            {
                Debug.Log("4");
                gameObject.GetComponent<RectTransform>().localScale -= new Vector3(scaleSpd, scaleSpd);
            }
        }
    }

    void setParent()
    {
        transform.SetParent(fCon.GetComponent<FlowchartController>().selectPanel.transform);
        isItIn = true;
    }

    public void resetParent()
    {
        transform.SetParent(parent.transform);
        isItIn = false;
    }

}