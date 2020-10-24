using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    public Text DisplayCoins;
    public static int coins;
    bool[] locked = {false, true, true, true, true, true};
    int[] prices = {0, 100, 200, 500, 1000, 2000};

    void Start(){
        coins = PlayerPrefs.GetInt("coins", coins);

        for (int i = 0; i < 6; i++) {
            locked[i] = PlayerPrefsX.GetBoolArray("locked")[i];
        }

        for(int i = 1; i < 6; i++){
            if (locked[i] == false){
                GameObject image = GameObject.FindGameObjectWithTag(i.ToString());
                Destroy(image.gameObject);
            }
        }
    }

    void Update(){
        DisplayCoins.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefsX.SetBoolArray("locked", locked);
    }

    public void PlayGame(){
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (locked[int.Parse(name)] == false){
            GameManager.instance.index = int.Parse(name);

            SceneManager.LoadScene("Gameplay");
        }

        if (locked[int.Parse(name)] == true && coins >= prices[int.Parse(name)]){
            coins = coins - prices[int.Parse(name)];
            locked[int.Parse(name)] = false;
            AudioScript.PlaySound("Purchase");
            GameObject image = GameObject.FindGameObjectWithTag(name);
            Destroy(image.gameObject);
        } 
    }
}
