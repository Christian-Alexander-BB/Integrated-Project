using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryHealth2 : MonoBehaviour
{
    // health of sentry2
    public float sentryHealth2 = 50;
    // ammo that will drop after sentry is destroyed
    public GameObject ammo2;

    // Start is called before the first frame update
    void Start()
    {
        // hide the ammo that is suppose to drop after destroying sentry gun
        ammo2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sentryHealth2 <= 0)
        {
            // destroy the sentry gun
            Destroy(gameObject);
            // drops the ammo after destroying the sentry gun
            ammo2.SetActive(true);
        }
    }
}
