using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask keypadMask;
    public float interactionDistance = 2f;
    public GameObject enterCodePrompt;
    public GameObject accessDeniedPrompt;
    public bool codeCorrect = false;
    public bool cardScanned;
    public bool tryFlag;
    public Animator openBankVault;

    // Start is called before the first frame update
    void Start()
    {
        // hide enter code prompt and access denied prompt first
        enterCodePrompt.SetActive(false);
        accessDeniedPrompt.SetActive(false);
        // get the boolean from another script
        cardScanned = gameObject.GetComponent<Card>().cardScanned;

    }

    // Update is called once per frame
    void Update()
    {
        cardScanned = gameObject.GetComponent<Card>().cardScanned;

        RaycastHit result;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, keypadMask))
        {
            if (result.transform.name == "Keypad")
            {
                // will not do anything after the correct code has been entered
                if (!codeCorrect && tryFlag)
                {
                    // show enter code prompt and hide access denied prompt if close
                    enterCodePrompt.SetActive(true);
                    accessDeniedPrompt.SetActive(false);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        // hide enter code prompt
                        enterCodePrompt.SetActive(false);

                        // UI to appear to type in the code

                        // if the code is correct
                        codeCorrect = true;

                        // if the code is wrong, show access denied prompt and disallow user to try again until they leave the proximity of the keypad and come back again
                        accessDeniedPrompt.SetActive(true);
                        tryFlag = false;

                        // open bank vault of keycode is correct and card is scanned
                        if (codeCorrect && cardScanned)
                        {
                            // set condition true for bank vault door to open
                            openBankVault.SetBool("allowOpenVault", true);
                        }
                }
                }
            }
        }

        else
        {
            // if raycast does not detect keypad, hide the enter code prompt and access denied prompt
            enterCodePrompt.SetActive(false);
            accessDeniedPrompt.SetActive(false);
            tryFlag = true;
        }
    }
}
