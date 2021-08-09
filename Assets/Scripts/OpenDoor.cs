using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask doorMask;
    public float interactionDistance = 2f;
    public GameObject doorPrompt;
    public bool doorOpenFlag = false;
    public Animator openDoor;

    // Start is called before the first frame update
    void Start()
    {
        doorPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // initialise raycasting to open doors
        RaycastHit result;
        // allow raycast to only detect items in Door layer
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, doorMask))
        {
            // if game object's name is Door, run the code below
            if (result.transform.name == "Door")
            {
                // display door prompt in UI
                doorPrompt.SetActive(true);
                // opens the door if player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!doorOpenFlag)
                    {
                        doorOpenFlag = true;
                        doorPrompt.SetActive(false);
                        // play animation for opening door
                        openDoor.SetBool("openDoor", true);
                    }

                    else if (doorOpenFlag)
                    {
                        doorOpenFlag = false;
                        doorPrompt.SetActive(false);
                        // play animation for closing door
                        openDoor.SetBool("openDoor", false);
                    }
                    
                }
            }
        }

        else
        {
            // hides door prompt if player is outside of the interaction distance
            doorPrompt.SetActive(false);
        }
    }
}
