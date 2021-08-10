using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackComputer : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask computerMask;
    public float interactionDistance = 2f;
    public GameObject uiPrompts;
    public GameObject hackPrompt;
    public GameObject code;
    public bool task3 = false;
    public string digit1 = "_ ";
    public string digit2 = "_ ";
    public string digit3 = "_ ";
    public string digit4 = "_ ";
    public string digit5 = "_ ";
    public string digit6 = "_ ";
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
        RaycastHit result;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, computerMask))
        {
            if (result.transform.name == "comp0")
            {
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

        if (!tryFlag1 && !tryFlag2 && !tryFlag3 && !tryFlag4 && !tryFlag5 && !tryFlag6)
        {
            uiPrompts.GetComponent<GameManager>().quest3.text = " 3 : Find all digits of the code. (completed)";
            task3 = true;
        }

    }
}
