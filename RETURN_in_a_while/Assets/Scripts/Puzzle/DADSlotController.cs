using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DADSlotController : MonoBehaviour, IDropHandler
{
    public GameObject child;
    GameObject soundBox;
    public bool hasSpecificAnswer = false; //유니티 에디터에서 지정하는 옵션 
    public bool useTag = false; //유니티 에디터에서 지정하는 옵션 
    public string answerTag; //유니티 에디터에서 지정하는 옵션 
    public bool tagIsNot = false; //유니티 에디터에서 지정하는 옵션
    public bool useKey = false; //유니티 에디터에서 지정하는 옵션 
    public string answerKey; //유니티 에디터에서 지정하는 옵션
    public bool keyIsNot = false; //유니티 에디터에서 지정하는 옵션 

    void Start()
    {
        soundBox = GameObject.Find("soundBox");
    }

    private void Update()
    {
        if (child != null)
        {
            if (gameObject.transform.childCount == 0)
            {
                child.GetComponent<DADBlockController>().isItIn = false;
                child = null;
            }
            //else if (child.GetComponent<DADBlockController>().isItIn == false)
            //{
            //    child = null;
            //}
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

            soundBox.GetComponent<GameSubSoundController>().on_inSFX();
        }
    }

    public bool isCorrect() //어느 부분에서 false 판단을 내렸는지 알 수 있는 변수가 있어야 함... 
    {
        if (hasSpecificAnswer)
        {
            if (tag == "multiArea")
            {
                Debug.Log(this.name + " is multiArea");

                int childCount = transform.childCount;
                if (childCount == 0 && answerKey != "0")
                {
                    return false;
                }
                for (int i = 0; i < childCount; ++i)
                {
                    //태그와 키 모두 지정한 경우: multiarea에서는 태그만을 사용하며, 키는 필요로 하는 요소 개수로 사용한다.
                    if (answerTag != "" && answerKey != "")
                    {
                        //부정태그가 들어있지 않거나 목표태그가 들어있고 / 목표 키 자리에 들어있는 개수가 자식 개체 개수와 일치할 경우
                        if (((tagIsNot && !transform.GetChild(i).CompareTag(answerTag)) || (!tagIsNot && transform.GetChild(i).CompareTag(answerTag)))
                            && (childCount.ToString() == answerKey))
                        {
                            continue;
                        }
                    }
                    else if (answerTag != "" && ((tagIsNot && !transform.GetChild(i).CompareTag(answerTag)) || (!tagIsNot && transform.GetChild(i).CompareTag(answerTag)))) //태그만 지정한 경우 
                    {
                        continue;
                    }
                    else if (answerKey != "" && (childCount.ToString() == answerKey)) //개체 개수만 지정한 경우 
                    {
                        continue;
                    }
                    //태그 또는 개체 개수가 맞지 않는 경우 
                    return false;
                }
                //multiArea 내의 모든 children이 조건을 만족한 경우
                return true;
            }
            else if (child)
            {
                bool tag, key = false;

                if (useTag)
                {
                    //부정태그가 아니고 태그가 정답일 경우 
                    if (!tagIsNot && child.CompareTag(answerTag))
                    {
                        tag = true;
                    }
                    //부정태그이고 태그가 오답이 아닐 경우
                    else if (tagIsNot && !child.CompareTag(answerTag))
                    {
                        tag = true;
                    }
                    else
                    {
                        tag = false;
                    }
                }
                else
                {
                    tag = true;
                }

                if (useKey)
                {
                    if (child)
                    {
                        //부정키가 아니고 키가 정답일 경우 
                        if (!keyIsNot && child.name == answerKey)
                        {
                            key = true;
                        }
                        //부정키이고 키가 오답이 아닐 경우  
                        else if (keyIsNot && child.name != answerKey)
                        {
                            key = true;
                        }
                        else
                        {
                            key = false;
                        }
                    }
                    else
                    {
                        key = false;
                    }
                }
                else
                {
                    key = true;
                }

                return tag && key;

                //태그 또는 키가 맞지 않는 경우
                //Debug.Log(this.name + " / " + (child ? child.name : "none") + " / " + (answerKey != "" ? answerKey : "none") + " / " + (answerTag != "" ? answerTag : "none"));
            }

            //child 지정된 오브젝트가 없을 경우(비어있음)
            //Debug.Log("empty child");

            return false; 
        }
        //정답에 관여하지 않는 경우 
        else
        {
            return true;
        }
    }
}
