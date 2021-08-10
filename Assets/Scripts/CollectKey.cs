using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask keyMask;
    public float interactionDistance = 2f;
    public GameObject collectKeyPrompt;
    public GameObject uiPrompts;
    public bool keyFound = false;
    public bool task7 = false;
    // Start is called before the first frame update
    void Start()
    {
        // hides the collect key prompt first
        collectKeyPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // initialise raycasting to detect the key
        RaycastHit result;
        // allow raycast to only detect objects in the key layer only
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, keyMask))
        {
            if (result.transform.name == "Key_2_lo")
            {
                // show the collect key prompt
                collectKeyPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    // player collects the key
                    keyFound = true;
                    uiPrompts.GetComponent<GameManager>().quest7.text = "7. Find the key for safety deposit box 1179. It is somewhere in the building. (completed)";
                    task7 = true;
                    // hides the key
                    result.transform.gameObject.SetActive(false);
                }
            }
        }

        else
        {
            // hides collect key prompt if player is out of range
            collectKeyPrompt.SetActive(false);
        }
    }
}
