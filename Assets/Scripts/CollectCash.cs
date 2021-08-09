using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCash : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask cashMask;
    public float interactionDistance = 2f;
    public GameObject collectCashPrompt;
    public int cash;
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
        RaycastHit result;
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
