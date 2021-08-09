using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDepBox : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask depBoxMask;
    public float interactionDistance = 2f;
    public GameObject openDepBoxPrompt;
    public GameObject needKeyPrompt;
    public bool keyFound;
    public bool tryFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        // hide the open deposit box prompt and need key prompt first
        openDepBoxPrompt.SetActive(false);
        needKeyPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // initialise raycasting to detect deposit box
        RaycastHit result;
        // allow raycast to detect objects in the deposit box layer only
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, depBoxMask))
        {
            if (result.transform.name == "")
            {
                // show open deposit box prompt
                openDepBoxPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // if key is not found and player is allowed to try, hide open deposit box prompt and show need key prompt
                    // and dont allow user to try again until they leave and come back
                    if (!keyFound && tryFlag)
                    {
                        openDepBoxPrompt.SetActive(false);
                        needKeyPrompt.SetActive(true);
                        tryFlag = false;
                    }

                    // if key is found, open the box for the player to collect the diamond.
                    else if (keyFound)
                    {
                        // play animation for opening the box
                        // set the red diamond object to reappear
                    }
                }
            }
        }

        else
        {
            // hides the open deposit prompt and need key prompt if the player out of range, and also allow the player to try again after leaving
            openDepBoxPrompt.SetActive(false);
            needKeyPrompt.SetActive(false);
            tryFlag = true;
        }
    }
}
