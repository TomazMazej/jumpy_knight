using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    private void OnEnable(){
        Player.playerDied += PlayerDied;
    }

    private void OnDisable(){
        Player.playerDied -= PlayerDied;
    }

    void PlayerDied(){
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("End");
    }
	
	public void GoToMainMenu(){
        SceneManager.LoadScene("Start");
    }

    public void doExitGame(){
        Application.Quit();
    }

    public void RestartGame(){
        SceneManager.LoadScene("MainMenu");
    }

   public void ShowLeaderboard(){
       Leaderboards.instance.ShowLeaderboardUI();
   }
}
