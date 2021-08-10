using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAmmo : MonoBehaviour
{
    // camera for fps player
    public Camera fpsCam;
    // set a layermask for the ammo
    public LayerMask ammoMask;
    // set interaction distance
    public float interactionDistance = 2f;
    // collect ammo prompt
    public GameObject collectAmmoPrompt;

    // number of bullets
    public int ammo = 10;
    // reference to the gun
    public GameObject vandal;

    // Start is called before the first frame update
    void Start()
    {
        // hide the prompt 
        collectAmmoPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // initialise raycasting to detect ammo
        RaycastHit result;
        // allow raycast to only detect objects in the ammo layer
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, ammoMask))
        {
            if (result.transform.name == "Ammo_Box_lo")
            {
                // show the collect ammo prompt
                collectAmmoPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    // hide ammo game object
                    result.transform.gameObject.SetActive(false);
                    // hide the prompt
                    collectAmmoPrompt.SetActive(false);
                    // increase ammo
                    vandal.GetComponent<Vandal>().ammo += 10;
                }
            }
        }

        else
        {
            // if player walks away from the ammo, prompt will hide
            collectAmmoPrompt.SetActive(false);
        }
    }
}
