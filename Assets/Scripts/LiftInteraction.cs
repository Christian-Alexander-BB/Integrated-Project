using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftInteraction : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask diamondMask;
    public float interactionDistance = 2f;
    public Animator liftLeft;
    public Animator liftRight;
    public GameObject task1Trigger;
    public bool questStarted = false;
    public bool allowEscape = false;
    public bool task1;
    public bool task2;
    public bool task3;
    public bool task4;
    public bool task5;
    public bool task6;
    public bool task7;
    public bool task8;
    public bool task9;


    // Start is called before the first frame update
    void Start()
    {
        // open the lift when the game starts
        liftLeft.SetBool("liftOpen", true);
        liftRight.SetBool("liftOpen", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (questStarted && !allowEscape)
        {
            liftLeft.SetBool("liftOpen", false);
            liftRight.SetBool("liftOpen", false);
        }

        task1 = task1Trigger.GetComponent<Quest1>().task1;
        task2 = gameObject.GetComponent<CollectCard>().task2;
        task3 = gameObject.GetComponent<HackComputer>().task3;
        task4 = gameObject.GetComponent<Keypad>().task4;
        task5 = gameObject.GetComponent<Keypad>().task5;
        task6 = gameObject.GetComponent<OpenDepBox>().task6;
        task7 = gameObject.GetComponent<CollectKey>().task7;
        task8 = gameObject.GetComponent<OpenDepBox>().task8;
        task9 = gameObject.GetComponent<CollectRedDiamond>().task9;

        if (task1 && task2 && task3 && task4 && task5 && task6 && task7 && task8 && task9)
        {
            allowEscape = true;
        }

        if (allowEscape)
        {
            liftLeft.SetBool("liftOpen", true);
            liftRight.SetBool("liftOpen", true);
        }
    }
}
