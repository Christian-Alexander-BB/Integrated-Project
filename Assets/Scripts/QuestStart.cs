using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestStart : MonoBehaviour
{
    public GameObject player;
    public GameObject uiPrompts;
    public bool questStarted;
    public bool allowEscape;

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
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(allowEscape);
            // if the quest have not started when player enter trigger, start the quest
            if (!player.GetComponent<LiftInteraction>().questStarted)
            {
                player.GetComponent<LiftInteraction>().questStarted = true;
            }

            // if player is allowed to escape, end the quest
            if (player.GetComponent<LiftInteraction>().allowEscape)
            {
                player.GetComponent<LiftInteraction>().questStarted = false;
                uiPrompts.GetComponent<GameManager>().quest10.text = "10. Escape. (completed)";
                SceneManager.LoadScene(3);
            }
        }

    }
}
