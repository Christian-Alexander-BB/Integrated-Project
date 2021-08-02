using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackComputer : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask computerMask;
    public float interactionDistance = 2f;
    public GameObject hackPrompt;

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
            if (result.transform.name == "Computer")
            {
                // show hack computer prompt if close
                hackPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // getting the codes should be here

                    // hide hack computer prompt
                    hackPrompt.SetActive(false);
                }
            }
        }

        else
        {
            // if raycast does not detect the computer, hide hack computer prompt
            hackPrompt.SetActive(false);
        }
    }
}
