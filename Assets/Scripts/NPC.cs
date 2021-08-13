using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Camera fpsCam;
    public GameObject vandal;
    public LayerMask npcMask;
    public float interactionDistance = 2f;
    public GameObject npcPrompt;
    public GameObject task1Trigger;
    public bool task1;
    public bool task2;
    public bool task3;
    public bool task4;
    public bool task5;
    public bool task6;
    public bool task7;
    public bool task8;
    public bool task9;
    public GameObject task1text;
    public GameObject task234text;
    public GameObject task5text;
    public GameObject task7text;
    public GameObject idletext;

    // Start is called before the first frame update
    void Start()
    {
        // hides the collect key prompt first
        npcPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // initialise raycasting to detect the key
        RaycastHit result;
        // allow raycast to only detect objects in the key layer only
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, npcMask))
        {
            if (result.transform.name == "NPC")
            {
                // show the collect key prompt
                npcPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!task1 && !(task2 && task3))
                    {
                        gameObject.GetComponent<PlayerMovement>().enabled = false;
                        fpsCam.GetComponent<MouseLook>().enabled = false;
                        vandal.GetComponent<Vandal>().enabled = false;
                        Cursor.visible = true;
                        task1text.SetActive(true);
                    }
                    if (task1&&!(task2 && task3))
                    {
                        gameObject.GetComponent<PlayerMovement>().enabled = false;
                        fpsCam.GetComponent<MouseLook>().enabled = false;
                        vandal.GetComponent<Vandal>().enabled = false;
                        Cursor.visible = true;
                        task234text.SetActive(true);
                    }
                    if ((task2&&task3)&&!(task5))
                    {
                        gameObject.GetComponent<PlayerMovement>().enabled = false;
                        fpsCam.GetComponent<MouseLook>().enabled = false;
                        vandal.GetComponent<Vandal>().enabled = false;
                        Cursor.visible = true;
                        task5text.SetActive(true);
                    }
                    if (((task4||task5)&&!task6)||task7)
                    {
                        gameObject.GetComponent<PlayerMovement>().enabled = false;
                        fpsCam.GetComponent<MouseLook>().enabled = false;
                        vandal.GetComponent<Vandal>().enabled = false;
                        Cursor.visible = true;
                        idletext.SetActive(true);
                    }
                    if (task6&&!task7)
                    {
                        gameObject.GetComponent<PlayerMovement>().enabled = false;
                        fpsCam.GetComponent<MouseLook>().enabled = false;
                        vandal.GetComponent<Vandal>().enabled = false;
                        Cursor.visible = true;
                        task7text.SetActive(true);
                    }
                }
            }
        }

        else
        {
            // hides collect key prompt if player is out of range
            npcPrompt.SetActive(false);
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
    }

    public void Resume()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        fpsCam.GetComponent<MouseLook>().enabled = true;
        vandal.GetComponent<Vandal>().enabled = true;
        Cursor.visible = false;
    }
}
