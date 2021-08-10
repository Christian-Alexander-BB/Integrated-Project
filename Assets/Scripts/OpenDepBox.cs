using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDepBox : MonoBehaviour
{
    public Camera fpsCam;
    public Animator doorSwing;
    public LayerMask depBoxMask;
    public float interactionDistance = 2f;
    public GameObject openDepBoxPrompt;
    public GameObject needKeyPrompt;
    public GameObject uiPrompts;
    public GameObject redDiamond;
    public int cash;
    public bool keyFound;
    public bool tryFlag = true;
    public bool interactedFlag = false;
    public bool task6 = false;
    public bool task8 = false;

    // Start is called before the first frame update
    void Start()
    {
        // hide the open deposit box prompt and need key prompt first
        openDepBoxPrompt.SetActive(false);
        needKeyPrompt.SetActive(false);
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
                if (!keyFound && tryFlag)
                {
                    // show open deposit box prompt
                    openDepBoxPrompt.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // boolean to check if player has interacted with the deposit box
                        interactedFlag = true;
                        // if key is not found and player is allowed to try, hide open deposit box prompt and show need key prompt
                        // and dont allow user to try again until they leave and come back
                        openDepBoxPrompt.SetActive(false);
                        needKeyPrompt.SetActive(true);
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
            uiPrompts.GetComponent<GameManager>().quest6.text = "6. Get the cash and interact with safety deposit box 1179. (completed)";
            task6 = true;
        }
    }
}
