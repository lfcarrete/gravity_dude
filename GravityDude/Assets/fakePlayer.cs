using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakePlayer : MonoBehaviour
{
    private Rigidbody2D player;

	public float Speed;

    bool canChangeGravity;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        player.velocity = new Vector2(Speed, player.velocity.y);
    }
}
