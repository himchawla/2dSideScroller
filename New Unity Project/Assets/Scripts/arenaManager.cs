﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arenaManager : Singleton<arenaManager>
{

    public GameObject arena2;
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
    gameManager.Instance.parallax.transform.position = new Vector3(gameManager.Instance.parallax.transform.position.x, -29, gameManager.Instance.parallax.transform.position.z);
    }

    public void arena2Begin()
    {
        player.transform.position = arena2.transform.position;
        player.GetComponent<PlayerMovement>().moveSpeed = 6;
        player.GetComponent<PlayerMovement>().jumpHeight = 5;
        player.GetComponent<PlayerMovement>().maxJumpCounter = 2;
    gameManager.Instance.parallax.transform.position = new Vector3(gameManager.Instance.parallax.transform.position.x, -29, gameManager.Instance.parallax.transform.position.z);
        waveManager.Instance.enemies[0].GetComponent<enemy_move_warrior>().speed = 0.5f;
    }

      public  void arena3Begin()
    {
        player.GetComponent<PlayerMovement>().moveSpeed = 3;
        player.GetComponent<PlayerMovement>().jumpHeight = 7;
        player.GetComponent<PlayerMovement>().maxJumpCounter = 1;
        gameManager.Instance.parallax.transform.position = new Vector3(gameManager.Instance.parallax.transform.position.x, -66, gameManager.Instance.parallax.transform.position.z);
    }

        public void arena4Begin()
    {
        player.GetComponent<PlayerMovement>().moveSpeed = 5;
        player.GetComponent<PlayerMovement>().jumpHeight = 4;
        player.GetComponent<PlayerMovement>().maxJumpCounter = 2;
        gameManager.Instance.parallax.transform.position = new Vector3(gameManager.Instance.parallax.transform.position.x, -66, gameManager.Instance.parallax.transform.position.z);
    }

}