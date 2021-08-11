using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : MonoBehaviour
{
    // refer to quest ui to change text
    public GameObject uiPrompts;
    // check if the task is done for escaping the bank
    public bool task1 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // if player walks into the trigger
        if (other.tag == "Player")
        {
            uiPrompts.GetComponent<GameManager>().quest1.text = "1. Find the bank vault. (complete)";
            // task is completed for escaping
            task1 = true;
        }
    }
}
