using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask cardSensorMask;
    public float interactionDistance = 2f;
    public GameObject useCardPrompt;
    public GameObject noCardPrompt;
    public bool cardScanned = false;
    public bool codeCorrect;
    public Animator openBankVault;
    public bool cardCollected;
    public bool tryFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        // hide the use card prompt and no card prompt first
        useCardPrompt.SetActive(false);
        noCardPrompt.SetActive(false);
        // get the boolean from another script
        codeCorrect = gameObject.GetComponent<Keypad>().codeCorrect;
    }

    // Update is called once per frame
    void Update()
    {
        // get the boolean from another script
        codeCorrect = gameObject.GetComponent<Keypad>().codeCorrect;

        // get whether the keycard has been collected
        cardCollected = gameObject.GetComponent<CollectCard>().cardCollected;

        // use raycasting to detect the card sensor in the card sensor layer
        RaycastHit result;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, cardSensorMask))
        {
            if (result.transform.name == "CardSensor")
            {
                // will not do anything after the card has been scanned
                if (!cardScanned && tryFlag)
                {
                    // show the use card prompt and hide the no card prompt if close
                    useCardPrompt.SetActive(true);
                    noCardPrompt.SetActive(false);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (cardCollected)
                        {
                            // hides the use card prompt
                            useCardPrompt.SetActive(false);

                            // use the card
                            cardScanned = true;

                            if (cardScanned && codeCorrect)
                            {
                                // set condition true for bank vault door to open
                                openBankVault.SetBool("allowOpenVault", true);
                            }
                        }

                        else if (!cardCollected)
                        {
                            // hide the use card prompt
                            useCardPrompt.SetActive(false);
                            // show the no card prompt
                            noCardPrompt.SetActive(true);
                            // disallow the user to try again unless he leaves the proximity of the card sensor
                            tryFlag = false;
                        }
                    }
                }
            }
        }

        else
        {
            // if raycast does not detect card sensor, hide the use card prompt and no card prompt
            useCardPrompt.SetActive(false);
            noCardPrompt.SetActive(false);
            // allows user to try to scan again after leaving the card sensor and coming back again
            tryFlag = true;
        }
    }
}
