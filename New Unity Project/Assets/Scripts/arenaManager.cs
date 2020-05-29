using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arenaManager : Singleton<arenaManager>
{

    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void arena1Begin()
    {
        player.GetComponent<PlayerMovement>().moveSpeed = 4;
        player.GetComponent<PlayerMovement>().jumpHeight = 10;
        player.GetComponent<PlayerMovement>().maxJumpCounter = 1;
    }

    public void arena2Begin()
    {
        player.GetComponent<PlayerMovement>().moveSpeed = 6;
        player.GetComponent<PlayerMovement>().jumpHeight = 5;
        player.GetComponent<PlayerMovement>().maxJumpCounter = 2;
    }

        void arena3Begin()
    {
        player.GetComponent<PlayerMovement>().moveSpeed = 3;
        player.GetComponent<PlayerMovement>().jumpHeight = 7;
        player.GetComponent<PlayerMovement>().maxJumpCounter = 1;
    }

        void arena4Begin()
    {
        player.GetComponent<PlayerMovement>().moveSpeed = 5;
        player.GetComponent<PlayerMovement>().jumpHeight = 4;
        player.GetComponent<PlayerMovement>().maxJumpCounter = 2;
    }

}
