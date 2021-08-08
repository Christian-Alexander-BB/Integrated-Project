using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : MonoBehaviour
{
    public GameObject uiPrompts;

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
        if (other.tag == "Player")
        {
            uiPrompts.GetComponent<GameManager>().quest1.text = "1. Find the bank vault. (complete)";
        }
    }
}
