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
    
    //players stats
    public static float health =100;
    public static float ammoleft = 20;

    public float playerHealth;
    public int ammo;
    

   

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
        //ammo = GetComponent<Vandal>().ammo;

        //on start the game set the int/float to respective 

        health = 100;
        ammoleft = 20;
        
        //find the game object
        //playerHealthtxt = GameObject.Find("playerHealthtxt").GetComponent<Text>();
        


        //set the text to respective text 
        quest1.text = " 1 : Find the bank vault.";
        quest2.text = " 2 : Find and obtain the keycard.";
        quest3.text = " 3 : Find all digits of the code.";
        quest4.text = " 4 : Use keycard and enter code.";
        quest5.text = " 5 : Open the vault.";
        quest6.text = " 6 : Get the cash and find safety deposit box 1179.";
        quest7.text = " 7 : Find the key for safety deposit box 1179. It is in the building somewhere.";
        quest8.text = " 8 : Return to the vault. Open safety deposit box 1179.";
        quest9.text = " 9 : Obtain the Red Diamond.";
        quest10.text = "10 :Escape";

    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<PlayerHealth>().health;
        ammo = vandal.GetComponent<Vandal>().ammo;

        //update health and some pickups for the ui 

        playerHealthtxt.text = " Health: " + playerHealth;
        Ammotxt.text = " Ammo: " + ammo;
        playerdeath();


        //check if ammo is left than 0 and set the ammo to 0
        if (ammoleft <= 0)
        {
            ammoleft = 0;
        }
       
        //check if keycard is found
       // if (CardSensor >= 1)
        //{
          //  quest2.text = "2 : Find and obtain the keycard ( complete)";
            
        //}

         

    }



    void playerdeath()
    {
        //set text to zero less than zero

        if (health <= 0)
        {
            health = 0;

            //load the scene
            SceneManager.LoadScene("Gameover");
        }

    }

}
