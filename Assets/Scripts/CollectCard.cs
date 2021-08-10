using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCard : MonoBehaviour
{
    // camera for fps player
    public Camera fpsCam;
    // set a layermask for the card
    public LayerMask cardMask;
    // set interaction distance
    public float interactionDistance = 2f;
    // collect card prompt
    public GameObject collectCardPrompt;
    // bool to check if card is collected
    public bool cardCollected = false;
    // refer to quest ui to change text
    public GameObject uiPrompts;
    // check if the task is done for escaping the bank
    public bool task2 = false;

    // Start is called before the first frame update
    void Start()
    {
        // hide the collect card prompt first
        collectCardPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // use raycasting to detect the card in the card layer
        RaycastHit result;
        // allow raycast to only detect objects in the card layer
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, cardMask))
        {
            if (result.transform.name == "weixiang_card")
            {
                // show the collect card prompt if close
                collectCardPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    // update quest ui
                    uiPrompts.GetComponent<GameManager>().quest2.text = "2. Find and obtain the keycard. (completed)";
                    // task is completed for escaping
                    task2 = true;
                    // card has been collected, hides the card and the collect card prompt
                    cardCollected = true;
                    result.transform.gameObject.SetActive(false);
                    collectCardPrompt.SetActive(false);
                }
            }
        }

        else
        {
            // if raycast does not detect the card, hide the collect card prompt
            collectCardPrompt.SetActive(false);
        }
    }
}
