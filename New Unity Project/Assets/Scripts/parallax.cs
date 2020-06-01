using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{

    private float length, startPosX, startPosY;
    public GameObject cam;

    
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = cam.transform.position.x * parallaxEffect;
        float temp = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPosX + dist, transform.position.y, transform.position.z);

        if(temp>(startPosX + length))
        startPosX+=length;
        else if(temp<(startPosX - length))
        startPosX-=length;

        // if(cam.transform.position.y>-35)
        // {
        //     transform.position = new Vector3(transform.position.x, -28, transform.position.z);

        // }
        // else
        // {
        //     transform.position = new Vector3(transform.position.x, -66, transform.position.z);

        // }
    }
}
