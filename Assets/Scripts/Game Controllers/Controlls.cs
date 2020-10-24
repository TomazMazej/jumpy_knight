using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour{
    public bool Pressed = false;
    public static float h;
    public static bool j;

    public void Left(){      
        h = -1;
        //print("-1");
    }

    public void Right(){
        h = 1;
        //print("1");
    }

    public void Hold(){
        h = 0;
        //print("-1");
    }

    public void Jump(){
        j = true;
    }

    public void noJump(){
        j = false;
    }
}
