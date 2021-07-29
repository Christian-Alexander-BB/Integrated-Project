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
                hackPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // getting the codes should be here

                    hackPrompt.SetActive(false);
                }
            }
        }

        else
        {
            hackPrompt.SetActive(false);
        }
    }
}
