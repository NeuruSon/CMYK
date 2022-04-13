using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueController : MonoBehaviour
{
    GameObject player;
    public bool isFollowing = true;
    float targetDistance;
    float allowedDistance = 3f;
    float followSpeed;
    Vector3 offset = new Vector3(-2, 0.5f, 0);

    void Start()
    {
        player = GameObject.Find("Hero");
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            followSpeed = 1f;
            transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, followSpeed * Time.deltaTime);
        }
    }
}
