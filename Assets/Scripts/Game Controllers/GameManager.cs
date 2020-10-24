using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [SerializeField]
    private GameObject[] players;

    [HideInInspector]
    public int index;

	void Awake () {
         MakeSingleton();
    }

    void OnEnable(){
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable(){
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }


    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
        if (SceneManager.GetActiveScene().name == "Gameplay"){
            Instantiate(players[index], new Vector3(224, 3, 0), Quaternion.identity);
        }
    }

    void MakeSingleton(){
        if (instance != null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ShowLeaderboard(){
        Leaderboards.instance.ShowLeaderboardUI();
    }
}
