using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    // camera for fps player
    public Camera fpsCam;
    // set a layermask for the computer
    public LayerMask keypadMask;
    // set interaction distance
    public float interactionDistance = 2f;

    // ui for entering the code
    public InputField enterCode;
    public GameObject enterCodeHeading;
    public GameObject okButton;

    // crosshair object to hide when entering the code
    public GameObject crosshair;

    // refer to quest ui to change text
    public GameObject uiPrompts;
    // use card prompt
    public GameObject useCardPrompt;
    // no card prompt
    public GameObject noCardPrompt;
    // enter code prompt
    public GameObject enterCodePrompt;
    // access denied prompt
    public GameObject accessDeniedPrompt;
    // refer to player weapon to stop shooting when entering the code
    public GameObject vandal;

    // check if the correct code has been entered
    public bool codeCorrect = false;
    // check if the card has been scanned
    public bool cardScanned = false;
    // check if the player has collected the card
    public bool cardCollected;
    // bool to allow the player to try
    public bool tryFlag = true;
    // check if the player has entered the code
    public bool triedCodeFlag = false;
    // bool to show and hide enter code prompt
    public bool allowPressFToShow = true;
    // bool to make sure the code only runs once
    public bool alreadyRun = false;
    
    // animation to open the bank vault
    public Animator openBankVault;

    // check if the tasks are done for escaping the bank
    public bool task4 = false;
    public bool task5 = false;

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
        // check if the card has been collected by the player
        cardCollected = gameObject.GetComponent<CollectCard>().cardCollected;

        // initialise raycasting to detect the keypad
        RaycastHit result;
        // allow raycast to only detect objects in the keypad layer only
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, keypadMask))
        {
            if (result.transform.name == "Keypad")
            {
                // if the player is allowed to try, and the player has not scanned the card
                if (tryFlag && !cardScanned)
                {
                    // show the use card prompt, hide the no card prompt
                    useCardPrompt.SetActive(true);
                    noCardPrompt.SetActive(false);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // if the player has the card, the player would be able to scan the card
                        if (cardCollected)
                        {
                            // hide the use card prompt
                            useCardPrompt.SetActive(false);

                            // use the card
                            cardScanned = true;
                        }

                        // if the player does not have the card, show no card prompt
                        else
                        {
                            // hides use card prompt, show no card prompt, stops user from trying again
                            useCardPrompt.SetActive(false);
                            noCardPrompt.SetActive(true);
                            tryFlag = false;
                        }
                    }
                }

                // if the player has already scanned the card and allowed to try
                else if (cardScanned && tryFlag && allowPressFToShow)
                {
                    // show enter code prompt and hide access denied prompt
                    enterCodePrompt.SetActive(true);
                    accessDeniedPrompt.SetActive(false);
                    
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

                        // hide the use card prompt
                        allowPressFToShow = false;
                    }
                }
            }
        }

        // if the player is out of range of the keypad, or not looking at the keypad
        else if (!Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, keypadMask))
        {
            allowPressFToShow = true;

            // if raycast does not detect keypad, hide the use card prompt and no card prompt
            useCardPrompt.SetActive(false);
            noCardPrompt.SetActive(false);
            // if raycast does not detect keypad, hide the enter code prompt and access denied prompt
            enterCodePrompt.SetActive(false);
            accessDeniedPrompt.SetActive(false);

            // if the code input was incorrect, allow the player to try again after leaving the proximity of the keypad
            if (!codeCorrect)
            {
                tryFlag = true;
            }

        }

        // if the player has tried to input the code, and input the correct code
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
            // task is completed for escaping
            task5 = true;

            // set crosshair to be shown again
            crosshair.SetActive(true);

            // allow player movement and navigation again
            gameObject.GetComponent<PlayerMovement>().enabled = true;
            fpsCam.GetComponent<MouseLook>().enabled = true;
            vandal.GetComponent<Vandal>().enabled = true;

            // stops user from trying again until they leave
            tryFlag = false;
        }

        // if the player has tried to input the code, and input the wrong code
        else if (!codeCorrect && triedCodeFlag && alreadyRun)
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

            // allows this if else statement to run only once
            alreadyRun = false;
        }


    }

    // function to be run by the okbutton after clicking on it
    public void checkCodeCorrect()
    {
        // if player tried to input code, quest considered completed
        uiPrompts.GetComponent<GameManager>().quest4.text = "4. Use keycard and enter code. (completed)";
        // task is completed for escaping
        task4 = true;

        // if the player input the correct code
        if (enterCode.GetComponent<InputField>().text == "175349")
        {
            codeCorrect = true;
            triedCodeFlag = true;
        }

        // if the player input the wrong code
        else
        {
            codeCorrect = false;
            triedCodeFlag = true;
            // for the above else if statement to run only once
            alreadyRun = true;
            // stops user from trying again until they leave
            tryFlag = false;
        }
    }
}
