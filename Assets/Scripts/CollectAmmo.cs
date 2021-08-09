using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAmmo : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask ammoMask;
    public float interactionDistance = 2f;
    public GameObject collectAmmoPrompt;

    public int ammo = 10;
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
        // initialise raycasting from the fps cam
        RaycastHit result;
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

        // if player walks away from the ammo, prompt will hide
        else
        {
            collectAmmoPrompt.SetActive(false);
        }
    }
}
