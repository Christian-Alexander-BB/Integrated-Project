using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask cardSensorMask;
    public float interactionDistance = 2f;
    public GameObject useCardPrompt;

    // Start is called before the first frame update
    void Start()
    {
        // hide the use card prompt first
        useCardPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // use raycasting to detect the card sensor in the card sensor layer
        RaycastHit result;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, cardSensorMask))
        {
            if (result.transform.name == "CardSensor")
            {
                // show the use card prompt if close
                useCardPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // hides the use card prompt
                    useCardPrompt.SetActive(false);
                }
            }
        }

        else
        {
            // if raycast does not detect card sensor, hide the use card prompt
            useCardPrompt.SetActive(false);
        }
    }
}
