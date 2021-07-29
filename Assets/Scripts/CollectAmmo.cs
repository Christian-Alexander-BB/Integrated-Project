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

    // Start is called before the first frame update
    void Start()
    {
        collectAmmoPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit result;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, ammoMask))
        {
            if (result.transform.name == "Ammo")
            {
                collectAmmoPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    result.transform.gameObject.SetActive(false);
                    collectAmmoPrompt.SetActive(false);
                    // increase ammo
                    ammo += 10;
                }
            }
        }

        else
        {
            collectAmmoPrompt.SetActive(false);
        }
    }
}
