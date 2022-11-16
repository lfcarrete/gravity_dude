using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
	private Rigidbody2D player;

	public float Speed;
    	
    float gravity;

    bool canChangeGravity;
	
    void Start () {
		player = GetComponent<Rigidbody2D> ();
        gravity = player.gravityScale;
        canChangeGravity = true;
	}
	
	void Update () {
        gravity = player.gravityScale;

        print(player.velocity);
		player.velocity = new Vector2(Speed, player.velocity.y);
        if(Input.GetAxis("Jump") > 0 && canChangeGravity){
            player.gravityScale = gravity * (-1);
            canChangeGravity = false;
            Invoke("setCanChangeGravity", 0.5f);
        }


	}

    void setCanChangeGravity() {
        canChangeGravity = true;
    }
}