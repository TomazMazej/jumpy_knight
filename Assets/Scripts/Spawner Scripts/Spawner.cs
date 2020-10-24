using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] monsterReference;

    private List<GameObject> monsters = new List<GameObject>();

    void Awake(){
        CreateMonsters();
    }

    void Start (){
		if(gameObject.name=="Left Spawner"){
            StartCoroutine(SpawnMonsters(1));
        }
        else{
            StartCoroutine(SpawnMonsters(2));
        }
	}

    void CreateMonsters(){
        int index = 0; 

        for(int i=0; i < monsterReference.Length * 3; i++){
            GameObject monster = Instantiate(monsterReference[index], transform.position, Quaternion.identity) as GameObject;
            monsters.Add(monster);
            monsters[i].SetActive(false);

            index++;
            if (index == monsterReference.Length)
                index = 0;

        }
    }

    IEnumerator SpawnMonsters(float waitTime){
        yield return new WaitForSeconds(waitTime);

        int randomIndex = Random.Range(0, monsters.Count);

        while (true){
            if (!monsters[randomIndex].activeInHierarchy){
                monsters[randomIndex].SetActive(true);
                monsters[randomIndex].transform.position = transform.position;
                break;
            }
            else{
                randomIndex = Random.Range(0, monsters.Count);
            }
        }

        if(gameObject.name=="Left Spawner"){
            monsters[randomIndex].GetComponent<Monster>().speed = Random.Range(4, 10);
            monsters[randomIndex].transform.localScale = new Vector3(-10, 10, 10);

        }
        else{
            monsters[randomIndex].GetComponent<Monster>().speed = -Random.Range(4, 10);
            monsters[randomIndex].transform.localScale = new Vector3(10, 10, -10);
        }
        StartCoroutine(SpawnMonsters(Random.Range(5,9)));
    }
}
