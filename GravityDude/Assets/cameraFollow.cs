using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraFollow : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update () {
        
        transform.position = new Vector3(transform.position.x + Speed, transform.position.y, transform.position.z);
        
    }
}