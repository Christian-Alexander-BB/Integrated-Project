using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryHealth1 : MonoBehaviour
{
    public float sentryHealth1 = 50;

    // Update is called once per frame
    void Update()
    {
        if (sentryHealth1 <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
