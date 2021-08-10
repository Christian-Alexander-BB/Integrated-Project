using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask npcMask;
    public float interactionDistance = 2f;
    public GameObject npcPrompt;
    public bool cardCollected;

    // Start is called before the first frame update
    void Start()
    {
        // hides the collect key prompt first
        npcPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // initialise raycasting to detect the key
        RaycastHit result;
        // allow raycast to only detect objects in the key layer only
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, npcMask))
        {
            if (result.transform.name == "NPC")
            {
                // show the collect key prompt
                npcPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (cardCollected)
                    {
                        Debug.Log("cardcollected");
                    }
                }
                
            }
        }

        else
        {
            // hides collect key prompt if player is out of range
            npcPrompt.SetActive(false);
        }
    }
}
