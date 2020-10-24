using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;

    private void Awake(){
        myBody = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        myBody.velocity = new Vector2(speed, 0);
	}

    private void OnTriggerEnter2D(Collider2D target){
        if (target.tag == "Boundary"){
            gameObject.SetActive(false);
        }
    }
}
