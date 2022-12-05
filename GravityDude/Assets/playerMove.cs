using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class playerMove : MonoBehaviour
{
	private Rigidbody2D player;
    public Transform trackingTarget;

    public GameObject canva;

	public float Speed;
    public float endX;
    public string level;
    public Transform playerSize;
    float gravity;
    float delta;
    private string _currentScene;
    bool canChangeGravity;
    bool isStuck;
    float inverso;

    public AudioSource audioSource;
    public AudioClip clipDeath;
    public AudioClip clipJump;
    public AudioClip clipWin;
	
    void Start () {
		player = GetComponent<Rigidbody2D> ();
        gravity = player.gravityScale;
        canChangeGravity = true;
        isStuck = false;
        audioSource = GetComponent<AudioSource>();
        _currentScene = SceneManager.GetActiveScene().name;
        inverso = -0.3f;
	}
	
	void Update () {
        gravity = player.gravityScale;
        delta = trackingTarget.position.x - player.position.x;
        if(isStuck){
            player.velocity = new Vector2(0, player.velocity.y+inverso*3.5f);
        } else {
            checkDistance(delta);
        }
        if(Input.GetAxis("Jump") > 0 && canChangeGravity){
            audioSource.PlayOneShot(clipJump);
            player.gravityScale = gravity * (-1);
            canChangeGravity = false;
            Invoke("setCanChangeGravity", 0.6f);
        }
        checkDistance(delta);

        if(player.position.x > endX){
            audioSource.PlayOneShot(clipWin);
            canva.SetActive(true);
            Invoke("loadNextLvl", 0.6f);
        }
	}
    void loadNextLvl() {
        SceneManager.LoadScene(level);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Wall") {
            isStuck = true;
        } else {
            isStuck = false;
        }

    }
    void Loss() {
        audioSource.PlayOneShot(clipDeath);
        canva.SetActive(true);
        Invoke("loadCurLvl", 0.6f);

    }

    void loadCurLvl() {
        Destroy(player);
        SceneManager.LoadScene(_currentScene);
    }

    void setCanChangeGravity() {
        canChangeGravity = true;
        transform.localScale = new Vector3(0.3f, inverso, 0.3f);
        inverso = inverso*-1f;
    }

    void checkDistance(float distance){
        if(distance > 6.0f || player.position.y > 5 || player.position.y < -10){
            Loss();
        }
        if(distance < -7.0f){
            player.velocity = new Vector2(Speed-0.5f, player.velocity.y);
        } else {
            player.velocity = new Vector2(Speed, player.velocity.y);
        }
    }
}