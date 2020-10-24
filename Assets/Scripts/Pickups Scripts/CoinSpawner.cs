using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    public GameObject coin;
    public GameObject spawner;
    public static bool exist;

    void Start(){
        exist = false;
        SpawnCoin();
    }

    void Update(){
        if (exist == false){
            SpawnCoin();
        }
    }

    void SpawnCoin(){
        System.Random rnd = new System.Random();
        int rand = rnd.Next(360, 460);
        spawner.transform.localPosition = new Vector3(rand, 20, transform.position.z);
        Instantiate(coin, transform.position, Quaternion.identity);
        exist = true;
    }
}
