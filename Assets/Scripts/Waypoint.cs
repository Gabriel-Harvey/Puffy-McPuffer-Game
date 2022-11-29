using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoint : MonoBehaviour
{
    public Image questImage;
    public Transform targetPosition;
    public Text distanceToTarget;
    public Camera cam;
    public Vector3 offset;
    Collectables hooked;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float minX = questImage.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = questImage.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minY;

        Vector2 pos = cam.WorldToScreenPoint(targetPosition.position);

        if (Vector3.Dot((targetPosition.position - transform.position), transform.forward) < 0)
        {
            //Target is behind camera
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        questImage.transform.position = pos;
        distanceToTarget.text = ((int)Vector3.Distance(targetPosition.position, transform.position)).ToString() + "m";

        if (hooked == true)
        {
            questImage.enabled = false;
            distanceToTarget.enabled = false;
        }
    }
}
