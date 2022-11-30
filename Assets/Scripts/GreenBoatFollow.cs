using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBoatFollow : MonoBehaviour
{
    public float followerSpeed = 10f;
    public float followerTurningSpeed = 10f;
    public Transform transformPlayer;
    public bool reachedPoint = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, transformPlayer.position) < 30 && Vector3.Distance(transform.position, transformPlayer.position) > 10)
        {
            if (reachedPoint == false)
            {
                Follow();
            }
        }
    }

    void Follow()
    {
        // Look at Player
        transform.rotation = Quaternion.Slerp(transform.rotation
        , Quaternion.LookRotation(transformPlayer.position - transform.position)
        , followerTurningSpeed * Time.deltaTime);

        // Move at Player
        transform.position += transform.forward * followerSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Point")
        {
            reachedPoint = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Point")
        {
            reachedPoint = false;
        }
    }
}
