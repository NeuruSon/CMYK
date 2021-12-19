using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FlowchartLineController : MonoBehaviour, IDragHandler,IEndDragHandler,IBeginDragHandler
{
    RectTransform line;
    float speed = 5f;
    float wLine = 0, hLine = 10;
    Vector2 startMousePos;
    Vector2 mousePos;

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - line.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        line.rotation = Quaternion.Slerp(line.rotation, rotation, speed * Time.deltaTime);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    void Start()
    {
        line = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - line.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        line.rotation = Quaternion.Slerp(line.rotation, rotation, speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            line.anchoredPosition = startMousePos;
            Debug.Log("click(" + startMousePos.x + ", " + startMousePos.y + ") - (" + line.anchoredPosition.x + ", " + line.anchoredPosition.y + ")");

        }

        if (Input.GetMouseButton(0))
        {

        }
    }
}



//public class FlowchartLineController : MonoBehaviour
//{
//    public LineRenderer Line;
//    public float lineWidth = 0.04f;
//    public float minimumVertexDistance = 0.1f;

//    private bool isLineStarted;

//    void Start()
//    {
//        // set the color of the line
//        Line.startColor = Color.red;
//        Line.endColor = Color.red;

//        // set width of the renderer
//        Line.startWidth = lineWidth;
//        Line.endWidth = lineWidth;

//        isLineStarted = false;
//        Line.positionCount = 0;
//    }

//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            Line.positionCount = 0;
//            Vector3 mousePos = GetWorldCoordinate(Input.mousePosition);

//            Line.positionCount = 2;
//            Line.SetPosition(0, mousePos);
//            Line.SetPosition(1, mousePos);
//            isLineStarted = true;
//        }

//        if (Input.GetMouseButton(0) && isLineStarted)
//        {
//            Vector3 currentPos = GetWorldCoordinate(Input.mousePosition);
//            float distance = Vector3.Distance(currentPos, Line.GetPosition(Line.positionCount - 1));
//            if (distance > minimumVertexDistance)
//            {
//                Debug.Log(distance);
//                UpdateLine();
//            }
//        }

//        if (Input.GetMouseButtonUp(0))
//        {
//            isLineStarted = false;
//        }
//    }

//    private void UpdateLine()
//    {
//        Line.positionCount++;
//        Line.SetPosition(Line.positionCount - 1, GetWorldCoordinate(Input.mousePosition));
//    }

//    private Vector3 GetWorldCoordinate(Vector3 mousePosition)
//    {
//        Vector3 mousePos = new Vector3(mousePosition.x, mousePosition.y, 1);
//        return Camera.main.ScreenToWorldPoint(mousePos);
//    }
//}
