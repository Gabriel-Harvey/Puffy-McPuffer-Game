

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    public GameObject questMenu;
    [SerializeField] bool menuUp;
    [SerializeField] Animator QuestMenuAnimator;
    [SerializeField] Collectables questScore;
    [SerializeField] Sprite[] questIconsArray;
    [SerializeField] Image questIconsImage;
    public GameObject crates;

    // Start is called before the first frame update
    void Start()
    {
        questScore = crates.GetComponent<Collectables>();
    }

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

        if (questScore.questScore >= 1)
        {
            questIconsImage.sprite = questIconsArray[1];
        }
    }
}

