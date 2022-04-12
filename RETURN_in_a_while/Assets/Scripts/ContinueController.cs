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
    RaycastHit ray;
    Vector3 velocity = Vector3.zero;

    void Start()
    {
        player = GameObject.Find("Hero");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFollowing)
        {
            transform.LookAt(player.transform);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out ray))
            {
                targetDistance = ray.distance;
                if (targetDistance >= allowedDistance)
                {
                    followSpeed = 0.75f;
                    transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref velocity, followSpeed * Time.deltaTime);
                }
            }
            else
            {
                followSpeed = 0f;
            }
        }
    }
}
