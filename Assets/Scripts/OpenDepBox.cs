using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDepBox : MonoBehaviour
{
    // camera for fps player
    public Camera fpsCam;

    // animation for opening the deposit box door
    public Animator doorSwing;

    // set a layermask for the computer
    public LayerMask depBoxMask;
    // set interaction distance
    public float interactionDistance = 2f;
    // open deposit box prompt
    public GameObject openDepBoxPrompt;
    // need key prompt
    public GameObject needKeyPrompt;
    // refer to quest ui to change text
    public GameObject uiPrompts;
    // red diamond object
    public GameObject redDiamond;

    // amount of cash
    public int cash;
    // check if the key has been found
    public bool keyFound;
    // allows the player to try to open the box
    public bool tryFlag = true;
    // check if the player has interacted with the box
    public bool interactedFlag = false;

    // check if the tasks are done for escaping the bank
    public bool task6 = false;
    public bool task8 = false;

    // Start is called before the first frame update
    void Start()
    {
        // hide the open deposit box prompt and need key prompt first
        openDepBoxPrompt.SetActive(false);
        needKeyPrompt.SetActive(false);

        // hide the red diamond first
        redDiamond.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // initialise raycasting to detect deposit box
        RaycastHit result;
        // allow raycast to detect objects in the deposit box layer only
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, depBoxMask))
        {
            if (result.transform.name == "Safety_Deposit_Box_Body")
            {
                // if key not found and player allowed to try
                if (!keyFound && tryFlag)
                {
                    // show open deposit box prompt
                    openDepBoxPrompt.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // boolean to check if player has interacted with the deposit box
                        interactedFlag = true;
                        // if key is not found and player is allowed to try, hide open deposit box prompt and show need key prompt
                        openDepBoxPrompt.SetActive(false);
                        needKeyPrompt.SetActive(true);
                        // disallow player to try again until they leave and come back
                        tryFlag = false;
                    }
                }

                // if key is found, open the box for the player to collect the diamond.
                else if (keyFound && tryFlag)
                {
                    // show open deposit box prompt
                    openDepBoxPrompt.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // boolean to check if player has interacted with the deposit box
                        interactedFlag = true;

                        // make the red diamond appear
                        redDiamond.SetActive(true);

                        // hides open deposit box prompt
                        openDepBoxPrompt.SetActive(false);

                        // play animation for opening the box
                        doorSwing.SetBool("keyFound", true);
                        // set the red diamond object to reappear

                        // update quest ui
                        uiPrompts.GetComponent<GameManager>().quest8.text = "8. Return to the vault. Open safety deposit box 1179. (complete)";
                        // task is completed for escaping
                        task8 = true;

                        // player cannnot interact with the safety deposit box anymore
                        tryFlag = false;
                    }
                }
            }
        }

        else
        {
            // hides the open deposit prompt and need key prompt if the player out of range, and also allow the player to try again after leaving, but not allowing the player to interact anymore after it has been opened.
            openDepBoxPrompt.SetActive(false);
            needKeyPrompt.SetActive(false);
            // if key has not been found, allow the player to try and interact again after leaving
            if (!keyFound)
            {
                tryFlag = true;
            }
        }

        // checks constantly how much cash the player has
        cash = gameObject.GetComponent<CollectCash>().cash;
        // checks constantly to see whether the key has been found or not
        keyFound = gameObject.GetComponent<CollectKey>().keyFound;

        // if player has interacted with the deposit box and have at least 1000 cash, player completed quest 6
        if (cash >= 1000 && interactedFlag)
        {
            // update quest ui
            uiPrompts.GetComponent<GameManager>().quest6.text = "6. Get the cash and interact with safety deposit box 1179. (completed)";
            // task is completed for escaping
            task6 = true;
        }
    }
}
