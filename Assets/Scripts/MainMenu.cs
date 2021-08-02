using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    //load menu 
    public void loadmenu(string MainMenu)
    {
        SceneManager.LoadScene("Menu");
    }

    //Load gamescene

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //quit game exit
    public void ExitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();

    }
}
