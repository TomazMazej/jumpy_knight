using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void doExitGame(){
        Application.Quit();
    }

    public void GoToAbout(){
        SceneManager.LoadScene("About");
    }

    public void GoToStart(){
        SceneManager.LoadScene("Start");
    }
}
