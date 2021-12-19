using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    Rigidbody r;
    float speed = 5f; //기준 이동 속도.
    float rotateSpeed = 7f;
    float jumpHeight = 16f;
    float moveSpeed;
    bool isGround = false;
    float X, Y;

    public GameObject pCam;
    GameObject gCon;

    public float getPlayerSpeed()
    {
        return speed;
    }

    void Start()
    {
        pCam = GameObject.Find("PlayerCamera");
        Physics.gravity = new Vector3(0, -29.8f, 0);
        r = GetComponent<Rigidbody>();
        moveSpeed = speed;
        gCon = GameObject.Find("GameController");
    }

    void Update()
    {
        if (!gCon.GetComponent<GameController>().isPaused) //게임이 진행중일 때만 이동할 수 있음 
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-1 * Vector3.forward * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(-1 * Vector3.left * moveSpeed * Time.deltaTime);
            }

            //달리기
            if (Input.GetKey(KeyCode.LeftShift) && isGround)
            {
                moveSpeed = 2 * speed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = speed;
            }

            //점프 
            if (Input.GetKey(KeyCode.Space) && isGround)
            {
                isGround = false;
                r.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }

            //마우스로 각도 회전
            if (Input.GetMouseButton(0))
            {
                //X축은 카메라만, Y축은 캐릭터와 카메라 모두 회전 
                transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -rotateSpeed, Input.GetAxis("Mouse X") * rotateSpeed, 0));
                Y = transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Euler(0, Y, 0);

                pCam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -rotateSpeed, Input.GetAxis("Mouse X") * rotateSpeed, 0));
                X = pCam.transform.rotation.eulerAngles.x;
                pCam.transform.rotation = Quaternion.Euler(X, Y, 0);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGround = true;
        }
    }
}
