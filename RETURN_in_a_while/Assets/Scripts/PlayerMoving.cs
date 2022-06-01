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
    Animator pAnim;

    public GameObject pCam, player;
    GameObject gCon;

    public float getPlayerSpeed()
    {
        return speed;
    }

    void Start()
    {
        Physics.gravity = new Vector3(0, -29.8f, 0);
        r = GetComponent<Rigidbody>();
        moveSpeed = speed;
        gCon = GameObject.Find("GameController");
        pAnim = player.GetComponent<Animator>();
    }

    void Update()
    {
        if (gCon.GetComponent<GameController>().isPaused == false) //게임이 진행중일 때만 이동할 수 있음 
        {
            if (Input.GetKey(KeyCode.W))
            {
                pAnim.SetInteger("walk", 1);
                player.transform.rotation = Quaternion.Euler(0, pCam.transform.rotation.eulerAngles.y, 0);
                transform.Translate(pCam.transform.forward.x * moveSpeed * Time.deltaTime, 0, pCam.transform.forward.z * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.W)) {
                pAnim.SetInteger("walk", 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                pAnim.SetInteger("walk", 1);
                player.transform.rotation = Quaternion.Euler(0, pCam.transform.rotation.eulerAngles.y - 90, 0);
                transform.Translate(-1 * pCam.transform.right.x * moveSpeed * Time.deltaTime, 0 , -1 * pCam.transform.right.z * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                pAnim.SetInteger("walk", 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                pAnim.SetInteger("walk", 1);
                player.transform.rotation = Quaternion.Euler(0, pCam.transform.rotation.eulerAngles.y - 180, 0);
                transform.Translate(-1 * pCam.transform.forward.x * moveSpeed * Time.deltaTime, 0, -1 * pCam.transform.forward.z * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                pAnim.SetInteger("walk", 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                pAnim.SetInteger("walk", 1);
                player.transform.rotation = Quaternion.Euler(0, pCam.transform.rotation.eulerAngles.y + 90, 0);
                transform.Translate(pCam.transform.right.x * moveSpeed * Time.deltaTime, 0, pCam.transform.right.z * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                pAnim.SetInteger("walk", 0);
            }


            //달리기
            if (Input.GetKey(KeyCode.LeftShift) && isGround)
            {
                pAnim.SetInteger("walk", 2);
                moveSpeed = 2.5f * speed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                pAnim.SetInteger("walk", 1);
                moveSpeed = speed;
            }

            //점프
            if (Input.GetKey(KeyCode.Space) && isGround)
            {
                isGround = false;
                r.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }

            //플레이어가 카메라 기준 정면을 바라보도록 돌려야 함.

            //마우스로 각도 회전
            if (Input.GetMouseButton(0))
            {
                //X축은 카메라만, Y축은 캐릭터와 카메라 모두 회전 
                //transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -rotateSpeed, Input.GetAxis("Mouse X") * rotateSpeed, 0));
                //Y = transform.rotation.eulerAngles.y;
                //transform.rotation = Quaternion.Euler(0, Y, 0);

                //회전은 카메라만 함 
                pCam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -rotateSpeed, Input.GetAxis("Mouse X") * rotateSpeed, 0));
                Y = pCam.transform.rotation.eulerAngles.y;

                pCam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -rotateSpeed, Input.GetAxis("Mouse X") * rotateSpeed, 0));
                X = pCam.transform.rotation.eulerAngles.x;

                pCam.transform.rotation = Quaternion.Euler(X, Y, 0);
            }
        }
        else
        {
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
