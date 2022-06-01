using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueController : MonoBehaviour
{
    GameObject player;
    public bool isFollowing = true;
    float followSpeed;
    public Vector3 offset = new Vector3(-2, 2, 0);

    void Start()
    {
        player = GameObject.Find("Hero");
    }

    void Update()
    {
        if (isFollowing)
        {
            followSpeed = 1f;
            transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, followSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, followSpeed * Time.deltaTime);
        }
    }
}
