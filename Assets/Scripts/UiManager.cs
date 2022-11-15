using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class UiManager : MonoBehaviour
{
    public GameObject questMenu;
    [SerializeField] bool menuUp;
    [SerializeField] Animator QuestMenuAnimator;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) & menuUp == false)
        {
            menuUp = true;
            QuestMenuAnimator.SetBool("MenuUp", true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) & menuUp == true)
        {
            menuUp = false;
            QuestMenuAnimator.SetBool("MenuUp", false);
        }
    }
}
