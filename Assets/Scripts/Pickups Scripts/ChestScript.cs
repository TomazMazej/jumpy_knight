﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour {

    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;

    private void Awake(){
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update(){
        myBody.velocity = new Vector2(speed, -7);
    }

    private void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag.Equals("Player")){
            MainMenuController.coins = MainMenuController.coins + 5;
            Timer.coins = Timer.coins + 5;
            PlayerPrefs.SetInt("coins", MainMenuController.coins);
            AudioScript.PlaySound("Coinpickup");
            Destroy(gameObject);
            ChestSpawner.exist2 = false;
        }
    }
}
