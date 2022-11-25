

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public GameObject selectedMarker;
    private CameraAim cameraAim;
    public Transform harpoonLockPos;

    public void Start()
    {
        cameraAim = GameObject.FindGameObjectWithTag("HarpoonLauncher").GetComponent<CameraAim>();
        selectedMarker.SetActive(false);
    }
    private void OnMouseEnter()
    {
        selectedMarker.SetActive(true);
        cameraAim.target = harpoonLockPos;
    }

    private void OnMouseExit()
    {
        selectedMarker.SetActive(false);
        cameraAim.target = null;
    }

    
}

