using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player;

    public float minX;
    public float maxX;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = transform.position; //kamera sledi igralcu
        temp.x = player.position.x;

        if (temp.x < minX)
            temp.x = minX;

        if (temp.x > maxX)
            temp.x = maxX;

        transform.position = temp;
	}
}
