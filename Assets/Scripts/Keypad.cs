using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask keypadMask;
    public float interactionDistance = 2f;
    public InputField enterCode;
    public GameObject enterCodeHeading;
    public GameObject okButton;
    public GameObject crosshair;
    public GameObject uiPrompts;
    public GameObject useCardPrompt;
    public GameObject noCardPrompt;
    public GameObject enterCodePrompt;
    public GameObject accessDeniedPrompt;
    public GameObject vandal;
    public bool codeCorrect = false;
    public bool cardScanned = false;
    public bool cardCollected;
    public bool tryFlag = true;
    public bool triedCodeFlag = false;
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

        // hides the ui for entering code first
        enterCodeHeading.SetActive(false);
        okButton.SetActive(false);
        enterCode.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        cardCollected = gameObject.GetComponent<CollectCard>().cardCollected;

        RaycastHit result;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, keypadMask))
        {
            if (result.transform.name == "Keypad")
            {
                if (tryFlag && !cardScanned)
                {
                    // show the use card prompt, hide the no card prompt
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
                            // hides use card prompt, show no card prompt, stops user from trying again
                            useCardPrompt.SetActive(false);
                            noCardPrompt.SetActive(true);
                            tryFlag = false;
                        }
                    }
                }

                else if (cardScanned && tryFlag)
                {
                    if (tryFlag)
                    {
                        // show enter code prompt ui
                        enterCodePrompt.SetActive(true);
                        accessDeniedPrompt.SetActive(false);
                    }

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        // show the cursor in game
                        Cursor.visible = true;

                        // hide enter code prompt
                        enterCodePrompt.SetActive(false);

                        // hide the crosshair to display enter code ui
                        crosshair.SetActive(false);

                        // stops player movement and navigation
                        gameObject.GetComponent<PlayerMovement>().enabled = false;
                        fpsCam.GetComponent<MouseLook>().enabled = false;
                        vandal.GetComponent<Vandal>().enabled = false;

                        // show ui for entering the code
                        enterCodeHeading.SetActive(true);
                        okButton.SetActive(true);
                        enterCode.gameObject.SetActive(true);
                    }
                }
            }
        }

        else if (!Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, keypadMask))
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

        if (codeCorrect && triedCodeFlag)
        {
            // hide the cursor in game
            Cursor.visible = false;

            // hide enter code prompt
            enterCodePrompt.SetActive(false);

            // hide ui for entering the code
            enterCodeHeading.SetActive(false);
            okButton.SetActive(false);
            enterCode.gameObject.SetActive(false);

            // play the animation for opening the bank vault
            openBankVault.SetBool("allowOpenVault", true);

            // change quest ui
            uiPrompts.GetComponent<GameManager>().quest5.text = "5. Open the vault. (completed)";

            // set crosshair to be shown again
            crosshair.SetActive(true);

            // allow player movement and navigation again
            gameObject.GetComponent<PlayerMovement>().enabled = true;
            fpsCam.GetComponent<MouseLook>().enabled = true;
            vandal.GetComponent<Vandal>().enabled = true;

            // stops user from trying again until they leave
            tryFlag = false;
        }

        else if (!codeCorrect && triedCodeFlag)
        {
            // hide the cursor in game
            Cursor.visible = false;

            // hide ui for entering the code
            enterCodeHeading.SetActive(false);
            okButton.SetActive(false);
            enterCode.gameObject.SetActive(false);

            // set crosshair to be shown again
            crosshair.SetActive(true);

            // show access denied prompt and hide enter code prompt
            accessDeniedPrompt.SetActive(true);
            enterCodePrompt.SetActive(false);

            // resets the input box
            enterCode.GetComponent<InputField>().text = "";

            // allow player movement and navigation again
            gameObject.GetComponent<PlayerMovement>().enabled = true;
            fpsCam.GetComponent<MouseLook>().enabled = true;
            vandal.GetComponent<Vandal>().enabled = true;

            // stops user from trying again until they leave
            tryFlag = false;
        }


    }

    public void checkCodeCorrect()
    {
        if (enterCode.GetComponent<InputField>().text == "175349")
        {
            codeCorrect = true;
            triedCodeFlag = true;
        }

        else
        {
            codeCorrect = false;
            triedCodeFlag = true;
        }
    }
}
