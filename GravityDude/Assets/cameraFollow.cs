using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraFollow : MonoBehaviour
{
    //public float Speed;
    public float followSpeed;
    public float yOffset;
    public float xOffset;
    public Transform trackingTarget;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update () {
        float xTarget = trackingTarget.position.x + xOffset;
        //float xTarget = followSpeed;
        //float yTarget = trackingTarget.position.y + yOffset;
        float yTarget = 0;

        float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);

        transform.position = new Vector3(xNew, yNew, transform.position.z);
        //transform.position = new Vector3(transform.position.x + Speed, transform.position.y, transform.position.z);
        
    }
}