using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask keypadMask;
    public float interactionDistance = 2f;
    public GameObject uiPrompts;
    public GameObject useCardPrompt;
    public GameObject noCardPrompt;
    public GameObject enterCodePrompt;
    public GameObject accessDeniedPrompt;
    public bool codeCorrect = false;
    public bool cardScanned = false;
    public bool cardCollected;
    public bool tryFlag = true;
    public Animator openBankVault;

    // Start is called before the first frame update
    void Start()
    {
        // hide use card prompt and no card prompt first
        useCardPrompt.SetActive(false);
        noCardPrompt.SetActive(false);

        // hide enter code prompt and access denied prompt first
        enterCodePrompt.SetActive(false);
        accessDeniedPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit result;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, keypadMask))
        {
            if (result.transform.name == "Keypad")
            {
                if (tryFlag && !cardScanned)
                {
                    useCardPrompt.SetActive(true);
                    noCardPrompt.SetActive(false);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (cardCollected)
                        {
                            // hide the use card prompt
                            useCardPrompt.SetActive(false);

                            // use the card
                            cardScanned = true;
                        }

                        else
                        {
                            useCardPrompt.SetActive(false);
                            noCardPrompt.SetActive(true);
                            tryFlag = false;
                        }
                    }
                }

                else if (cardScanned)
                {
                    enterCodePrompt.SetActive(true);
                    accessDeniedPrompt.SetActive(false);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        // if the code is correct
                        codeCorrect = true;
                        openBankVault.SetBool("allowOpenVault", true);
                        uiPrompts.GetComponent<GameManager>().quest5.text = " 5 : Open the vault. (completed)";

                        // if the code is wrong
                        accessDeniedPrompt.SetActive(false);
                        tryFlag = false;
                    }
                }

                // will not do anything after the correct code has been entered
                //if (!codeCorrect && tryFlag)
                //{
                    // show enter code prompt and hide access denied prompt if close
                    //enterCodePrompt.SetActive(true);
                    //accessDeniedPrompt.SetActive(false);
                    //if (Input.GetKeyDown(KeyCode.F))
                    //{
                        // hide enter code prompt
                        //enterCodePrompt.SetActive(false);

                        // UI to appear to type in the code

                        // if the code is correct
                        //codeCorrect = true;

                        // if the code is wrong, show access denied prompt and disallow user to try again until they leave the proximity of the keypad and come back again
                        //accessDeniedPrompt.SetActive(true);
                        //tryFlag = false;

                        // open bank vault of keycode is correct and card is scanned
                        //if (codeCorrect && cardScanned)
                        //{
                            // set condition true for bank vault door to open
                            //openBankVault.SetBool("allowOpenVault", true);
                        //}
                //}
                //}
            }
        }

        else
        {
            // if raycast does not detect keypad, hide the enter code prompt and access denied prompt
            useCardPrompt.SetActive(false);
            noCardPrompt.SetActive(false);
            enterCodePrompt.SetActive(false);
            accessDeniedPrompt.SetActive(false);
            if (!codeCorrect)
            {
                tryFlag = true;
            }
        }

        cardCollected = gameObject.GetComponent<CollectCard>().cardCollected;
    }
}
