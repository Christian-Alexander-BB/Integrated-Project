using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRedDiamond : MonoBehaviour
{
    // camera for fps player
    public Camera fpsCam;
    // set a layermask for the red diamond
    public LayerMask diamondMask;
    // set interaction distance
    public float interactionDistance = 2f;
    // refer to quest ui to change text
    public GameObject uiPrompts;
    // collect diamond prompt
    public GameObject collectDiamondPrompt;
    // check if diamond has been collected
    public bool diamondCollected = false;
    // check if the task is done for escaping the bank
    public bool task9 = false;

    // Start is called before the first frame update
    void Start()
    {
        // hides the collect diamond prompt first
        collectDiamondPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // initialise raycasting to detect the diamond
        RaycastHit result;
        // allow raycast to only detect objects in the diamond layer only
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, diamondMask))
        {
            if (result.transform.name == "Red_Diamond_3")
            {
                // show the collect diamond prompt
                collectDiamondPrompt.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    // set diamond to be collected
                    diamondCollected = true;
                    // update quest ui
                    uiPrompts.GetComponent<GameManager>().quest9.text = "9. Obtain the Red Diamond. (completed)";
                    // task is completed for escaping
                    task9 = true;
                    // hide the red diamond
                    result.transform.gameObject.SetActive(false);
                }
            }
        }

        else
        {
            // hides the collect diamond prompt if the player is out of range
            collectDiamondPrompt.SetActive(false);
        }
    }
}
