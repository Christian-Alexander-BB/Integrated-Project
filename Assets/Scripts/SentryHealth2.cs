using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryHealth2 : MonoBehaviour
{
    public float sentryHealth2 = 50;

    // Update is called once per frame
    void Update()
    {
        if (sentryHealth2 <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
