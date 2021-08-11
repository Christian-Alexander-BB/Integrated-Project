using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftInteraction : MonoBehaviour
{
    // camera for fps player
    public Camera fpsCam;
    // set interaction distance
    public float interactionDistance = 2f;

    // animation for the opening and closing of the lift doors
    public Animator liftLeft;
    public Animator liftRight;

    // game object that detects whether the task1 has been completed
    public GameObject task1Trigger;

    // check if the player has started the quest
    public bool questStarted = false;

    // check if the player has completed the tasks in the quest for escaping
    public bool allowEscape = false;

    // set the variables for whether the tasks have been completed
    public bool task1;
    public bool task2;
    public bool task3;
    public bool task4;
    public bool task5;
    public bool task6;
    public bool task7;
    public bool task8;
    public bool task9;

    // set the quest ui
    public GameObject quest2;
    public GameObject quest3;
    public GameObject quest4;
    public GameObject quest5;
    public GameObject quest6;
    public GameObject quest7;
    public GameObject quest8;
    public GameObject quest9;
    public GameObject quest10;


    // Start is called before the first frame update
    void Start()
    {
        // open the lift when the game starts
        liftLeft.SetBool("liftOpen", true);
        liftRight.SetBool("liftOpen", true);

        // hide some quest ui
        quest2.SetActive(false);
        quest3.SetActive(false);
        quest4.SetActive(false);
        quest5.SetActive(false);
        quest6.SetActive(false);
        quest7.SetActive(false);
        quest8.SetActive(false);
        quest9.SetActive(false);
        quest10.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if the player started the quest, and not allowed to escape
        if (questStarted && !allowEscape)
        {
            liftLeft.SetBool("liftOpen", false);
            liftRight.SetBool("liftOpen", false);
        }

        // checks whether the tasks have been completed in their respective scripts
        task1 = task1Trigger.GetComponent<Quest1>().task1;
        task2 = gameObject.GetComponent<CollectCard>().task2;
        task3 = gameObject.GetComponent<HackComputer>().task3;
        task4 = gameObject.GetComponent<Keypad>().task4;
        task5 = gameObject.GetComponent<Keypad>().task5;
        task6 = gameObject.GetComponent<OpenDepBox>().task6;
        task7 = gameObject.GetComponent<CollectKey>().task7;
        task8 = gameObject.GetComponent<OpenDepBox>().task8;
        task9 = gameObject.GetComponent<CollectRedDiamond>().task9;

        // if task 1 is completed, show quest 2
        if (task1)
        {
            quest2.SetActive(true);
        }

        // if task 2 is completed, show quest 3
        if (task2)
        {
            quest3.SetActive(true);
        }

        // if task 3 is completed, show quest 4
        if (task3)
        {
            quest4.SetActive(true);
        }

        // if task 4 is completed, show quest 5
        if (task4)
        {
            quest5.SetActive(true);
        }

        // if task 5 is completed, show quest 6
        if (task5)
        {
            quest6.SetActive(true);
        }

        // if task 6 is completed, show quest 7
        if (task6)
        {
            quest7.SetActive(true);
        }

        // if task 7 is completed, show quest 8
        if (task7)
        {
            quest8.SetActive(true);
        }

        // if task 8 is completed, show quest 9
        if (task8)
        {
            quest9.SetActive(true);
        }

        // if task 9 is completed, show quest 10
        if (task9)
        {
            quest10.SetActive(true);
        }

        // if all the tasks are completed, the player is allowed to escape
        if (task1 && task2 && task3 && task4 && task5 && task6 && task7 && task8 && task9)
        {
            allowEscape = true;
        }

        // if the player is allowed to escape, lift doors will be open
        if (allowEscape)
        {
            liftLeft.SetBool("liftOpen", true);
            liftRight.SetBool("liftOpen", true);
        }
    }
}
