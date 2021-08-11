using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCash : MonoBehaviour
{
    // camera for fps player
    public Camera fpsCam;
    // set a layermask for the cash
    public LayerMask cashMask;
    // set interaction distance
    public float interactionDistance = 2f;
    // collect cash prompt
    public GameObject collectCashPrompt;
    // amount of cash collected
    public int cash;
    // whether 1000 dollars has been collected
    public bool cashCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        // hides the collect cash prompt first
        collectCashPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // initialise raycasting to detect cash
        RaycastHit result;
        // allow raycast to only detect objects in the cash layer
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, cashMask))
        {
            if (result.transform.name == "Cash_2_lo")
            {
                // show the collect cash prompt
                collectCashPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    // addes the amount of cash to the player
                    cash += 100;
                    // player has collected enough cash
                    if (cash >= 1000)
                    {
                        cashCollected = true;
                    }
                    // hides cash
                    result.transform.gameObject.SetActive(false);
                }

            }

        }

        else
        {
            // hides the collect cash prompt if player leaves
            collectCashPrompt.SetActive(false);
        }
    }
}
