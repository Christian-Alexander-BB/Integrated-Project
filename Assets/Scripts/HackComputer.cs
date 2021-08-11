using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackComputer : MonoBehaviour
{
    // camera for fps player
    public Camera fpsCam;
    // set a layermask for the computer
    public LayerMask computerMask;
    // set interaction distance
    public float interactionDistance = 2f;
    // refer to quest ui to change text
    public GameObject uiPrompts;
    // hack prompt
    public GameObject hackPrompt;
    // ui object that shows the code
    public GameObject code;
    // check if the task is done for escaping the bank
    public bool task3 = false;

    // setting the digits to be empty to begin
    public string digit1 = "_ ";
    public string digit2 = "_ ";
    public string digit3 = "_ ";
    public string digit4 = "_ ";
    public string digit5 = "_ ";
    public string digit6 = "_ ";

    // check if player has interacted with the computer
    public bool tryFlag1 = true;
    public bool tryFlag2 = true;
    public bool tryFlag3 = true;
    public bool tryFlag4 = true;
    public bool tryFlag5 = true;
    public bool tryFlag6 = true;

    // Start is called before the first frame update
    void Start()
    {
        // hide hack computer prompt first
        hackPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // initialise raycasting to detect the computer
        RaycastHit result;
        // allow raycast to only detect objects in the computer layer only
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, computerMask))
        {
            if (result.transform.name == "comp0")
            {
                // if player has already interacted with the computer, stop player from interacting with the computer again
                if (tryFlag1)
                {
                    hackPrompt.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        digit1 = "1 ";
                        // getting the codes should be here
                        code.GetComponent<Text>().text = "Code: " + digit1 + digit2 + digit3 + digit4 + digit5 + digit6;

                        // hide hack computer prompt
                        hackPrompt.SetActive(false);

                        // interaction with computer disabled
                        tryFlag1 = false;
                    }
                }

                // show hack computer prompt if close
            }

            if (result.transform.name == "comp1")
            {
                // if player has already interacted with the computer, stop player from interacting with the computer again
                if (tryFlag2)
                {
                    // show hack computer prompt if close
                    hackPrompt.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        digit2 = "7 ";
                        // getting the codes should be here
                        code.GetComponent<Text>().text = "Code: " + digit1 + digit2 + digit3 + digit4 + digit5 + digit6;

                        // hide hack computer prompt
                        hackPrompt.SetActive(false);

                        // interaction with computer disabled
                        tryFlag2 = false;
                    }
                }
            }

            if (result.transform.name == "comp2")
            {
                // if player has already interacted with the computer, stop player from interacting with the computer again
                if (tryFlag3)
                {
                    // show hack computer prompt if close
                    hackPrompt.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        digit3 = "5 ";
                        // getting the codes should be here
                        code.GetComponent<Text>().text = "Code: " + digit1 + digit2 + digit3 + digit4 + digit5 + digit6;

                        // hide hack computer prompt
                        hackPrompt.SetActive(false);

                        // interaction with computer disabled
                        tryFlag3 = false;
                    }
                }
            }

            if (result.transform.name == "comp3")
            {
                // if player has already interacted with the computer, stop player from interacting with the computer again
                if (tryFlag4)
                {
                    // show hack computer prompt if close
                    hackPrompt.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        digit4 = "3 ";
                        // getting the codes should be here
                        code.GetComponent<Text>().text = "Code: " + digit1 + digit2 + digit3 + digit4 + digit5 + digit6;

                        // hide hack computer prompt
                        hackPrompt.SetActive(false);

                        // interaction with computer disabled
                        tryFlag4 = false;
                    }
                }
            }

            if (result.transform.name == "comp4")
            {
                // if player has already interacted with the computer, stop player from interacting with the computer again
                if (tryFlag5)
                {
                    // show hack computer prompt if close
                    hackPrompt.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        digit5 = "4 ";
                        // getting the codes should be here
                        code.GetComponent<Text>().text = "Code: " + digit1 + digit2 + digit3 + digit4 + digit5 + digit6;

                        // hide hack computer prompt
                        hackPrompt.SetActive(false);

                        // interaction with computer disabled
                        tryFlag5 = false;
                    }
                }
            }

            if (result.transform.name == "comp5")
            {
                // if player has already interacted with the computer, stop player from interacting with the computer again
                if (tryFlag6)
                {
                    // show hack computer prompt if close
                    hackPrompt.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        digit6 = "9 ";
                        // getting the codes should be here
                        code.GetComponent<Text>().text = "Code: " + digit1 + digit2 + digit3 + digit4 + digit5 + digit6;

                        // hide hack computer prompt
                        hackPrompt.SetActive(false);

                        // interaction with computer disabled
                        tryFlag6 = false;
                    }
                }
            }

        }

        else
        {
            // if raycast does not detect the computer, hide hack computer prompt
            hackPrompt.SetActive(false);
        }

        // if player has interacted with all the computers, the code has been found
        if (!tryFlag1 && !tryFlag2 && !tryFlag3 && !tryFlag4 && !tryFlag5 && !tryFlag6)
        {
            // update quest ui
            uiPrompts.GetComponent<GameManager>().quest3.text = " 3 : Find all digits of the code. (completed)";
            // task is completed for escaping
            task3 = true;
        }

    }
}
