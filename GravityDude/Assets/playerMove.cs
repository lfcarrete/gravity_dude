using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class playerMove : MonoBehaviour
{
	private Rigidbody2D player;
    public Transform trackingTarget;
	public float Speed;
    public Transform playerSize;
    float gravity;
    float delta;
    private string _currentScene;
    bool canChangeGravity;
    bool isStuck;
    float inverso;
	
    void Start () {
		player = GetComponent<Rigidbody2D> ();
        gravity = player.gravityScale;
        canChangeGravity = true;
        isStuck = false;
        _currentScene = SceneManager.GetActiveScene().name;
        inverso = -0.3f;
	}
	
	void Update () {
        gravity = player.gravityScale;
        delta = trackingTarget.position.x - player.position.x;
        if(isStuck){
            player.velocity = new Vector2(0, player.velocity.y);
            checkDistance(delta);
        } else {
            checkDistance(delta);
        }
        if(Input.GetAxis("Jump") > 0 && canChangeGravity){
            player.gravityScale = gravity * (-1);
            canChangeGravity = false;
            Invoke("setCanChangeGravity", 0.7f);
        }

	}

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Wall") {
            isStuck = true;
        } else {
            isStuck = false;
        }

    }
    void Loss() {
        Destroy(player);
        SceneManager.LoadScene(_currentScene);
    }
    void setCanChangeGravity() {
        canChangeGravity = true;
        transform.localScale = new Vector3(0.3f, inverso, 0.3f);
        inverso = inverso*-1f;
    }

    void checkDistance(float distance){
        if(distance < -7.0f){
            player.velocity = new Vector2(Speed-0.5f, player.velocity.y);
        } else {
            if(distance > 6.0f){
                Loss();
            }
            player.velocity = new Vector2(Speed, player.velocity.y);
        }
    }

}