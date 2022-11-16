

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonBoatMovement : MonoBehaviour
{
    [SerializeField] private GameObject harpoon;
    [SerializeField] private float speed;
    public bool moving;
    public float rotateSpeed = 5f;
    
    void Update()
    {
        if (moving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, harpoon.transform.position, speed * Time.deltaTime); //*

            var targetRotation = Quaternion.LookRotation(harpoon.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }

        

        
    }

    public void Actived(GameObject poon)
    {
        harpoon = poon;
        moving = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NearHookable")
        {
            moving = false;
        }
    }
}

