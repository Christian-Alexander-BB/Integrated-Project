using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCard : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask cardMask;
    public float interactionDistance = 2f;
    public GameObject collectCardPrompt;
    public bool cardCollected = false;
    public GameObject uiPrompts;

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
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, cardMask))
        {
            if (result.transform.name == "weixiang_card")
            {
                // show the collect card prompt if close
                collectCardPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    // sets the card to be collected, hides the card and the collect card prompt
                    uiPrompts.GetComponent<GameManager>().quest2.text = " 2. Find and obtain the keycard. (complete)";
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
