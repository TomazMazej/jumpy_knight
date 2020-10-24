using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    private float moveForce = 22f;
    public float jumpForce;
    public float maxVelocity;

    private Rigidbody2D myBody;
    private Animator anim;
    private bool grounded = false;

    public delegate void PlayerDied();
    public static event PlayerDied playerDied;

    public static bool dead = false;
    public float k=0;
    private bool Pdied = true;

    void Awake(){
        dead = false;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();       
    }

    void FixedUpdate(){
        if (Pdied == true){
            PlayerMoveKeyboard();
        }
    }

    public void PlayerMoveKeyboard(){
        float forceX = 0f;
        float forceY = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        k = Controlls.h; //Input.GetAxisRaw("Horizontal");

        if (k > 0){ //če gremo desno
            if (vel < maxVelocity)
                forceX = moveForce;

            Vector3 temp = transform.localScale; //se obrne v smer kamor hodimo
            temp.x = -10f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
            //Controlls.h = 0;
        }

        else if (k < 0){ //če gremo levo

            if (vel < maxVelocity)
                forceX = -moveForce;

            Vector3 temp = transform.localScale;
            temp.x = 10f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
            //Controlls.h = 0;
        }

        else{
            anim.SetBool("Walk", false); //stoji  na miru 
        }

        if (Controlls.j == true){ 
            if (grounded == true){
                grounded = false;
                forceY = jumpForce;
            }
            Controlls.j = false;
        }
        myBody.AddForce(new Vector2(forceX, forceY));
    }
    void OnCollisionEnter2D(Collision2D target){
        if (target.gameObject.tag == "Ground")
            grounded = true;

        if (target.gameObject.tag == "Monster"){
            if (playerDied != null){
                dead = true;
                playerDied();
                Pdied = false;
                AudioScript.PlaySound("Death");
                anim.SetBool("Die", true);
            }
            //Destroy(gameObject);
        }  
    }

    void OnTriggerEnter2D(Collider2D target){
        if (target.tag == "Monster"){
            if (playerDied != null){
                dead = true;
                playerDied();
                Pdied = false;
                AudioScript.PlaySound("Death");
                anim.SetBool("Die", true);
            }
            //Destroy(gameObject);
        }
    }
}

