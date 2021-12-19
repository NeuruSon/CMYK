using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FlowchartLineController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    SpriteRenderer sprite;
    GameObject fCon, parent;
    

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
        fCon.GetComponent<FlowchartController>().isSelectMode = true;
        setParent();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("up");
    }

    void Start()
    {
        fCon = GameObject.Find("FlowchartController");
        parent = transform.parent.gameObject;
    }

    void Update()
    {

    }

    void setParent()
    {
        transform.SetParent(fCon.GetComponent<FlowchartController>().selectPanel.transform);
    }

    void resetParent()
    {
        transform.SetParent(parent.transform);
    }
}