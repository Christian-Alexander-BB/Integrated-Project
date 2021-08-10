using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRedDiamond : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask diamondMask;
    public float interactionDistance = 2f;
    public GameObject uiPrompts;
    public GameObject collectDiamondPrompt;
    public bool diamondCollected = false;
    public bool task9 = false;

    // Start is called before the first frame update
    void Start()
    {
        collectDiamondPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit result;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, diamondMask))
        {
            if (result.transform.name == "Red_Diamond_3")
            {
                collectDiamondPrompt.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    diamondCollected = true;
                    uiPrompts.GetComponent<GameManager>().quest9.text = "9. Obtain the Red Diamond. (completed)";
                    task9 = true;
                    result.transform.gameObject.SetActive(false);
                }
            }
        }

        else
        {
            collectDiamondPrompt.SetActive(false);
        }
    }
}
