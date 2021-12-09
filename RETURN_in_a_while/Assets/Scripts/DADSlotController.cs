using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DADSlotController : MonoBehaviour, IDropHandler
{
    public GameObject child;
    public bool hasSpecificAnswer = false; //유니티 에디터에서 지정하는 옵션 
    public string answerTag, answerKey; //유니티 에디터에서 지정하는 옵션

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
                child.GetComponent<DADBlockController>().resetParent();
                child.GetComponent<DADBlockController>().resetOffset();
            }
            child = eventData.pointerDrag; //들고 있는 블럭을 child에 넣어준다
            //들고 있는 트랜스폼의 앵커포지션 = 현재 오브젝트(슬롯) 트랜스폼의 앵커포지션으로
            child.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            child.transform.SetParent(this.transform);
        }
    }

    public bool isCorrect() //어느 부분에서 false 판단을 내렸는지 알 수 있는 변수가 있어어. 
    {
        if (hasSpecificAnswer)
        {
            if (child != null)
            {
                //태그와 키 모두 지정한 경우 
                if (answerTag != null && answerKey != null && child.CompareTag(answerTag) && child.name == answerKey)
                {
                    return true;
                }
                else if (answerTag != null && child.CompareTag(answerTag)) //태그만 지정한 경우 
                {
                    return true;
                }
                else if (answerKey != null && child.name == answerKey) //키만 지정한 경우 
                {
                    return true;
                }
                //태그 또는 키가 맞지 않는 경우 
                return false;
            }
            //child 지정된 오브젝트가 없을 경우(비어있음) 
            return false; 
        }
        //answer 태그를 단 오브젝트를 정답 처리함(디폴트) 
        else
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
}
