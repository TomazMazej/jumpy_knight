using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text DisplayCoins;
    public static int coins;

    public Text timerText;
    private float startTime;

    public static float Score;
    public static float HighScore;
    public static string HighScoreTXT;
    public static string ScoreTXT;

    private float m;
    private float s;
    public static string minutes;
    public static string seconds;

    void Start () {
        coins = 0;
        startTime = Time.time;
        HighScore = PlayerPrefs.GetFloat("HighScore", HighScore);
        HighScoreTXT = PlayerPrefs.GetString("HighScoreTXT", HighScoreTXT);
    }
	
	void Update () {

        if (Player.dead){
            return;
        }

        DisplayCoins.text = coins.ToString();

        float t = Time.time - startTime;

        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f0");

        m = ((int)t / 60);
        s = (t % 60);

        if (int.Parse(seconds) < 10){
            seconds = "0" + seconds;
        }
        if (int.Parse(seconds) == 60){
            minutes = (m+1).ToString();
            seconds = "00";
        }
       
        timerText.text = minutes + ":" + seconds;
        ScoreTXT = minutes + ":" + seconds;
        //Debug.Log(ScoreTXT);

        Score = m*60+s;

        if (Score > HighScore){
            HighScore = Score;
            HighScoreTXT = minutes + ":" + seconds;
            Leaderboards.instance.AddScoreToLeaderboard(GPGSIds.leaderboard_score_leaderboard, (long)HighScore);
            PlayerPrefs.SetFloat("HighScore", HighScore);
            PlayerPrefs.SetString("HighScoreTXT", HighScoreTXT);
        }

        //print("Score: " + Score);
        //print("HighScore: " + HighScore);
    }
}
