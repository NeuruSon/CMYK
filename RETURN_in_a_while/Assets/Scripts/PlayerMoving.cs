using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Rigidbody r;
    protected float speed = 5f; //이동 속도.
    float rotateSpeed = 7f;
    float jumpHeight = 9f;
    public float moveSpeed;
    bool isGround = false;

    public Camera pCam;

    public float getPlayerSpeed()
    {
        return speed;
    }

    void Start()
    {
        Physics.gravity = new Vector3(0, -12.8f, 0);
        r = GetComponent<Rigidbody>();
        moveSpeed = speed;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
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
        float X = Input.GetAxis("Mouse X") * rotateSpeed; //왼쪽 오른쪽 두리번 두리번 
        float Y = Input.GetAxis("Mouse Y") * rotateSpeed; //위쪽 아래쪽 두리번 두리번 근데 너는 한 바퀴 돌면 안 됨;
        transform.Rotate(0, X, 0); //왼쪽 오른쪽 두리번 두리번

        if (pCam.transform.eulerAngles.x + (-Y) > 80 && pCam.transform.eulerAngles.x + (-Y) < 280)
            return; //조건만 만족하면 딱히 쓸 게 없음 
        else //모가지가 더 돌아가면 한정 범위 내 최솟값으로 바꿔부러라 
            pCam.transform.RotateAround(transform.position, pCam.transform.right, -Y); //RotateAround는 위치와 각도 모두 바꿔버리는데 위치 간섭을 제한하기 위해 transform.position(지금 위치) 그대로 설정하게 만듦.
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGround = true;
        }
    }
}
