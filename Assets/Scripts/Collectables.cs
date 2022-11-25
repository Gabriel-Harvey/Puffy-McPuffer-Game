

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public Transform boat;
    [SerializeField] bool hooked;
    private float speed;
    [SerializeField] Harpoon harpoon;
    [SerializeField] Transform lockPosition;
    [SerializeField] private bool locked;
    [SerializeField] private float rotateSpeed;
    public int questScore;


    private void Update()
    {
        if (hooked == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, boat.position, speed * Time.deltaTime);
        }

        if (locked == true)
        {
            transform.LookAt(transform.position + (boat.position - transform.position));
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
            questScore += 1;
            locked = true;
            gameObject.GetComponent<SelectionManager>().enabled = false;
            
            print(questScore);
        }
    }
}

