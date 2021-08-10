using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestStart : MonoBehaviour
{
    // reference to the player
    public GameObject player;
    // refer to quest ui to change text
    public GameObject uiPrompts;

    // check if the player has started the quest
    public bool questStarted;

    // check if the player is allowed to escape
    public bool allowEscape;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // if the quest have not started when player enter trigger, start the quest
            if (!player.GetComponent<LiftInteraction>().questStarted)
            {
                player.GetComponent<LiftInteraction>().questStarted = true;
            }

            // if player is allowed to escape, end the quest
            if (player.GetComponent<LiftInteraction>().allowEscape)
            {
                player.GetComponent<LiftInteraction>().questStarted = false;
                // update quest ui
                uiPrompts.GetComponent<GameManager>().quest10.text = "10. Escape. (completed)";
                // load winning scene
                SceneManager.LoadScene(3);
            }
        }

    }
}
