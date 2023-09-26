using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject menu;
    bool opened = false;

    //makes sure the menu is closed when the game starts
    void Start() { menu.SetActive(false); }

    //toggles the menu state
    public void menuOpen()
    {
        if (opened) { opened = false; menu.SetActive(false); }
        else { opened = true; menu.SetActive(true); }
    }

    //restarts the scene when button pressed
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //closes the game
    public void quitGame()
    {
        Application.Quit();
    }
    public void sensChanged()
    {
        
    }
}
