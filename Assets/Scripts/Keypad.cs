using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask keypadMask;
    public float interactionDistance = 2f;
    public GameObject enterCodePrompt;

    // Start is called before the first frame update
    void Start()
    {
        // hide enter code prompt first
        enterCodePrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit result;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, keypadMask))
        {
            if (result.transform.name == "Keypad")
            {
                // show enter code prompt if close
                enterCodePrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    // UI to appear to type in the code
                }
            }
        }

        else
        {
            // if raycast does not detect keypad, hide the enter code prompt
            enterCodePrompt.SetActive(false);
        }
    }
}
