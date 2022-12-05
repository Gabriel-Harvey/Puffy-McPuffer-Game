using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBoatRacing : MonoBehaviour
{
    public bool raceAllowed = false;
    public GameObject interactImage;
    public Transform transformPlayer;
    public BoatMovement playerRaceCondition;
    public float raceSpeed = 30f;
    public float raceSmoothTime = 0.5f;
    public float raceTurnSpeed = 20f;
    public float countdown = 5f;
    public int countdownInt;
    public bool reachedPoint = false;
    public bool finishedQuest = false;
    public bool turn = false;
    public bool startCounter = false;
    public GameObject raceGoal;
    public GameObject startPos;
    public GameObject levelGoal;
    Vector3 velocityBoat;

    [SerializeField]
    private KeyCode raceButton;
    public UiManager raceUI;

    // Start is called before the first frame update
    void Start()
    {
       // raceGoal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (raceAllowed == true)
        {
            if (reachedPoint == false)
            {
                transform.position = Vector3.SmoothDamp(transform.position, raceGoal.transform.position, ref velocityBoat, raceSmoothTime, raceSpeed);
                transform.rotation = Quaternion.Slerp(transform.rotation
                ,Quaternion.LookRotation(raceGoal.transform.position - transform.position)
                ,raceTurnSpeed * Time.deltaTime);
            }
        }
        if(raceAllowed == false && Vector3.Distance(transform.position, transformPlayer.position) < 20)
        {
            if (playerRaceCondition.wonRace == false)
            {
                interactImage.SetActive(true);
                if (Input.GetKeyDown(raceButton))
                {
                    startCounter = true;

                    interactImage.SetActive(false);
                    // raceGoal.SetActive(true);
                    StartCoroutine(Wait());
                }
                if (startCounter == true)
                {
                    raceUI.countdownRace.enabled = true;
                    if (countdown >= 0)

                        countdown -= Time.deltaTime;
                    countdownInt = Mathf.RoundToInt(countdown);
                    raceUI.countdownRace.text = "Race starts in... " + countdownInt.ToString() + "!";
                }
                else
                {
                    startCounter = false;
                }
            }

            else
            {
                raceUI.countdownRace.enabled = false;
                countdown = 5;
            }
        }
                
            
        
        if(raceAllowed == true || Vector3.Distance(transform.position, transformPlayer.position) > 20)
        {
            interactImage.SetActive(false);
        } 

        if (reachedPoint == true)
        {
            raceGoal.SetActive(false);
            StartCoroutine(StartAgain());
        }
        if (playerRaceCondition.wonRace == true)
        {
            raceGoal.SetActive(false);
            raceAllowed = false;
            StartCoroutine(Lost());
        }
    }

    public IEnumerator Wait()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
        yield return new WaitForSeconds(5);
        raceAllowed = true;
        startCounter = false;
    }
    public IEnumerator Lost()
    {
        yield return new WaitForSeconds(0.1f);
        print("go to waypoint");
        //insert point for where boat should go when done
        transform.position = Vector3.SmoothDamp(transform.position, levelGoal.transform.position, ref velocityBoat, raceSmoothTime, raceSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation
                , Quaternion.LookRotation(levelGoal.transform.position - transform.position)
                , raceTurnSpeed * Time.deltaTime);
    }

    public IEnumerator StartAgain()
    {
        transform.position = Vector3.SmoothDamp(transform.position, startPos.transform.position, ref velocityBoat, raceSmoothTime, raceSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation
                , Quaternion.LookRotation(startPos.transform.position - transform.position)
                , raceTurnSpeed * Time.deltaTime);

        yield return new WaitForSeconds(5);

        reachedPoint = false;
        raceAllowed = false;
            transform.rotation = Quaternion.Slerp(transform.rotation
                , Quaternion.LookRotation(raceGoal.transform.position - transform.position)
                , raceTurnSpeed * Time.deltaTime);
        StopCoroutine(StartAgain());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            reachedPoint = true;
        }

        if (other.tag == "Finish")
        {
            finishedQuest = true;
        }
    }
}
