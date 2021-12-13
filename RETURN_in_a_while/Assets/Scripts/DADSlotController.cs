using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DADSlotController : MonoBehaviour, IDropHandler
{
    public GameObject child;
    public bool hasSpecificAnswer = false; //유니티 에디터에서 지정하는 옵션 
    public string answerTag; //유니티 에디터에서 지정하는 옵션 
    public bool tagIsNot = false; //유니티 에디터에서 지정하는 옵션 
    public string answerKey; //유니티 에디터에서 지정하는 옵션
    public bool keyIsNot = false; //유니티 에디터에서 지정하는 옵션 

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
            if (child != null && tag != "multiArea") //이미 블럭이 들어있었다면 && multiArea가 아니면
            {
                //기존에 들어있던 블럭을 초기 위치로 보내고 (들고 있던 블럭을 block에 넣어준다)
                child.GetComponent<DADBlockController>().isItIn = false;
                child.GetComponent<DADBlockController>().resetParent();
                child.GetComponent<DADBlockController>().resetOffset();
            }
            child = eventData.pointerDrag; //들고 있는 블럭을 child에 넣어준다
            child.transform.SetParent(this.transform);

            if (tag != "multiArea") //multiArea가 아니면
            {
                //들고 있는 트랜스폼의 앵커포지션 = 현재 오브젝트(슬롯) 트랜스폼의 앵커포지션으로 -> 자식으로 설정한 뒤 pivot 중앙에 고정
                child.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                child.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            }
        }
    }

    public bool isCorrect() //어느 부분에서 false 판단을 내렸는지 알 수 있는 변수가 있어야 함... 
    {
        if (hasSpecificAnswer)
        {
            if (tag == "multiArea")
            {
                Debug.Log(this.name + " is multiArea");

                int childCount = transform.GetChildCount();
                for (int i = 0; i < childCount; ++i)
                {
                    //태그와 키 모두 지정한 경우
                    if (answerTag != "" && answerKey != "")
                    {
                        //부정태그가 들어있지 않거나 목표태그가 들어있고 / 부정키가 들어있지 않거나 목표키가 들어있으면
                        if (((tagIsNot && !transform.GetChild(i).CompareTag(answerTag)) || (!tagIsNot && transform.GetChild(i).CompareTag(answerTag)))
                            && ((keyIsNot && transform.GetChild(i).name != answerKey) || (!keyIsNot && transform.GetChild(i).name == answerKey)))
                        {
                            continue;
                        }
                    }
                    else if (answerTag != "" && ((tagIsNot && !transform.GetChild(i).CompareTag(answerTag)) || (!tagIsNot && transform.GetChild(i).CompareTag(answerTag)))) //태그만 지정한 경우 
                    {
                        continue;
                    }
                    else if (answerKey != "" && ((keyIsNot && transform.GetChild(i).name != answerKey) || (!keyIsNot && transform.GetChild(i).name == answerKey))) //키만 지정한 경우 
                    {
                        continue;
                    }
                    //태그 또는 키가 맞지 않는 경우 
                    return false;
                }
                //multiArea 내의 모든 children이 조건을 만족한 경우 
                return true;
            }
            else if (child != null)
            {
                //태그와 키 모두 지정한 경우 
                if (answerTag != "" && answerKey != "")
                {
                    //부정태그가 들어있지 않거나 목표태그가 들어있고 / 부정키가 들어있지 않거나 목표키가 들어있으면
                    if (((tagIsNot && !child.CompareTag(answerTag)) || (!tagIsNot && child.CompareTag(answerTag)))
                        && ((keyIsNot && child.name != answerKey) || (!keyIsNot && child.name == answerKey)))
                    {
                        return true;
                    }
                }
                else if (answerTag != "" && ((tagIsNot && !child.CompareTag(answerTag)) || (!tagIsNot && child.CompareTag(answerTag)))) //태그만 지정한 경우 
                {
                    return true;
                }
                else if (answerKey != "" && ((keyIsNot && child.name != answerKey) || (!keyIsNot && child.name == answerKey))) //키만 지정한 경우 
                {
                    return true;
                }
                //태그 또는 키가 맞지 않는 경우
                Debug.Log(this.name + " / " + (child ? child.name : "none") + " / " + (answerKey != "" ? answerKey : "none") + " / " + (answerTag != "" ? answerTag : "none"));
                return false;
            }
            else if (answerKey == "" && answerTag == "")
            {
                return true;
            }
            //child 지정된 오브젝트가 없을 경우(비어있음)
            Debug.Log("empty child");
            return false; 
        }
        //정답에 관여하지 않는 경우 
        else
        {
            return true;
        }
    }
}
