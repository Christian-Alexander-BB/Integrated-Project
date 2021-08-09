using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryHealth1 : MonoBehaviour
{
    public float sentryHealth1 = 50;
    public GameObject ammo1;

    // Start is called before the first frame update
    void Start()
    {
        // hide the ammo that is suppose to drop after destroying sentry gun
        ammo1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sentryHealth1 <= 0)
        {
            // destroy the sentry gun
            Destroy(gameObject);
            // drops the ammo after destroying the sentry gun
            ammo1.SetActive(true);
        }
    }
}
