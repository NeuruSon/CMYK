using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class DADBlockController : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    Vector3 offset; //초기 위치 저장
    GameObject parent;
    public bool isItIn = false; //DADSlotController에서 접근해 사용

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        offset = GetComponent<Transform>().transform.localPosition;
        parent = this.transform.parent.gameObject;
    }

    private void Start()
    {
        this.GetComponent<SortingGroup>().sortingOrder = 1;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isItIn = false;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        this.GetComponent<SortingGroup>().sortingOrder = 2;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        this.GetComponent<SortingGroup>().sortingOrder = 1;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void resetOffset()
    {
        this.GetComponent<RectTransform>().anchoredPosition = offset;
    }

    public void resetParent()
    {
        this.transform.SetParent(parent.transform);
    }
}
