using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DADSlotController : MonoBehaviour, IDropHandler
{
    public GameObject child;

    private void Update()
    {
        if (child != null)
        {
            if (child.GetComponent<DADBlockController>().isItIn == false)
            {
                child = null;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) //무언가 들고 있었다?
        {
            eventData.pointerDrag.GetComponent<DADBlockController>().isItIn = true;
            if (child != null) //이미 블럭이 들어있었다면 
            {
                //기존에 들어있던 블럭을 초기 위치로 보내고 (들고 있던 블럭을 block에 넣어준다)
                child.GetComponent<DADBlockController>().isItIn = false;
                child.GetComponent<DADBlockController>().resetOffset();
            }
            child = eventData.pointerDrag; //들고 있는 블럭을 child에 넣어준다
            child.transform.SetParent(this.transform);
            //들고 있는 트랜스폼의 앵커포지션 = 현재 오브젝트(슬롯) 트랜스폼의 앵커포지션으로
            child.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public bool isCorrect()
    {
        if (child != null)
        {
            if (child.tag == "answer")
            {
                return true;
            }
            return false;
        }
        return false;
    }
}
