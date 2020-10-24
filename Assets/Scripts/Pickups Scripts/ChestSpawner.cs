using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour {

    public GameObject chest;
    public GameObject spawner;
    public static bool exist2;

    void Start(){
        exist2 = false;
    }

    void Update(){
        if (exist2 == false){
            StartCoroutine(SpawnChest());
            exist2 = true;
        }
    }

    public IEnumerator SpawnChest(){
        yield return new WaitForSeconds(30);
        System.Random rnd = new System.Random();
        int rand = rnd.Next(360, 460);
        spawner.transform.localPosition = new Vector3(rand, 20, transform.position.z);
        Instantiate(chest, transform.position, Quaternion.identity);
    }
}
