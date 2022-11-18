using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerMove : MonoBehaviour
{
	private Rigidbody2D player;
    public Transform trackingTarget;
	public float Speed;
    	
    float gravity;
    float delta;

    bool canChangeGravity;
    bool isStuck;
	
    void Start () {
		player = GetComponent<Rigidbody2D> ();
        gravity = player.gravityScale;
        canChangeGravity = true;
        isStuck = false;
	}
	
	void Update () {
        gravity = player.gravityScale;
        delta = trackingTarget.position.x - player.position.x;
        print(delta);
        if(isStuck){
            player.velocity = new Vector2(0, player.velocity.y);
        } else {
            if(delta > 7.0f){
                player.velocity = new Vector2(Speed-0.5f, player.velocity.y);
            } else {
                player.velocity = new Vector2(Speed, player.velocity.y);
            }
        }
        if(Input.GetAxis("Jump") > 0 && canChangeGravity){
            player.gravityScale = gravity * (-1);
            canChangeGravity = false;
            Invoke("setCanChangeGravity", 0.5f);
        }

	}

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Wall") {
            isStuck = true;
        } else {
            isStuck = false;
        }

    }
    void setCanChangeGravity() {
        canChangeGravity = true;
    }
}