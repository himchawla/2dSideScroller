using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnOverlap : MonoBehaviour
{
    public bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("Enemy"))
    {
        canSpawn = false;
    }
    else 
    {
        canSpawn = true;
    }
}

private void OnTriggerExit2D(Collider2D other) {
    if(other.gameObject.CompareTag("Enemy"))
    {
        canSpawn = true;
    }
}

}