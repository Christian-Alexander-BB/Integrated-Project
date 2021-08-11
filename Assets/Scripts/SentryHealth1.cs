using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryHealth1 : MonoBehaviour
{
    // reference to the first person player
    public GameObject player;
    // health of sentry1
    public float sentryHealth1 = 50;
    // ammo that will drop after sentry is destroyed
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
            // continue player health regen
            player.GetComponent<PlayerHealth>().notTakingDamage = true;

            // hide the sentry gun
            gameObject.SetActive(false);
            // drops the ammo after destroying the sentry gun
            ammo1.SetActive(true);
        }
    }
}
