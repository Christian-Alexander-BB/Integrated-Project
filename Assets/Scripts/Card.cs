using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask cardMask;
    public float interactionDistance = 2f;
    public GameObject useCardPrompt;

    // Start is called before the first frame update
    void Start()
    {
        useCardPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit result;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, cardMask))
        {
            if (result.transform.name == "CardSensor")
            {
                useCardPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    useCardPrompt.SetActive(false);
                }
            }
        }

        else
        {
            useCardPrompt.SetActive(false);
        }
    }
}
