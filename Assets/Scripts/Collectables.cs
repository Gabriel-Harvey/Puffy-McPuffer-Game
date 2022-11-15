using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public Transform Boat;
    [SerializeField] bool hooked;
    private float speed;
    [SerializeField] Harpoon harpoon;
    [SerializeField] Transform lockPosition;


    private void Update()
    {
        if (hooked == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Boat.position, speed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Harpoon")
        {
            harpoon = collision.gameObject.GetComponentInParent<Harpoon>();
            speed = harpoon.speed;
            hooked = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBoat" & hooked == true)
        {
            transform.SetParent(other.transform);
            hooked = false;
            lockPosition = other.GetComponentInChildren<HarpoonAim>().collecionArea;
            harpoon.DestroyHarpoon();
            transform.position = lockPosition.position;
        }
    }
}
