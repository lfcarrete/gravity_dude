using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class beginScript : MonoBehaviour
{
    public Rigidbody2D player;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void clicked(){
        player.velocity = new Vector2(5, 0);
        Invoke("NextLvl", 2f);
    }
    void NextLvl(){
        SceneManager.LoadScene("level1");
    }
}
