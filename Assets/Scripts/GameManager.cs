using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;
    public GameObject vandal;
    
    //ui text for added on the ui
    public Text playerHealthtxt;
    public Text Ammotxt;
    public Text Cashtxt;
    
    //players stats
    public static float health =100;
    public static float ammoleft = 20;

    public float playerHealth;
    public int ammo;
    public int cash;
    

   

    /// <summary>
    /// Quest text ui update
    /// </summary>
    public Text quest1;
    public Text quest2;
    public Text quest3;
    public Text quest4;
    public Text quest5;
    public Text quest6;
    public Text quest7;
    public Text quest8;
    public Text quest9;
    public Text quest10;


    // Start is called before the first frame update
    void Start()
    {
        //set the text to respective text 
        quest1.text = "1. Find the bank vault.";
        quest2.text = "2. Find and obtain the keycard.";
        quest3.text = "3. Find all digits of the code.";
        quest4.text = "4. Use keycard and enter code.";
        quest5.text = "5. Open the vault.";
        quest6.text = "6. Get the cash and interact with safety deposit box 1179.";
        quest7.text = "7. Find the key for safety deposit box 1179. It is somewhere in the building.";
        quest8.text = "8. Return to the vault. Open safety deposit box 1179.";
        quest9.text = "9. Obtain the Red Diamond.";
        quest10.text = "10. Escape.";

    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<PlayerHealth>().health;
        ammo = vandal.GetComponent<Vandal>().ammo;
        cash = player.GetComponent<CollectCash>().cash;

        //update health and some pickups for the ui 

        playerHealthtxt.text = " Health: " + playerHealth;
        Ammotxt.text = " Ammo: " + ammo;
        Cashtxt.text = " Cash: " + cash + " / 1000";
        
    }
}
