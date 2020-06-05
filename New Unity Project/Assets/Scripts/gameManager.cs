using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : Singleton<gameManager>
{
        public int money;
        public int moneyVal;
        public GameObject canvas;
        public int maxHealth;
        public bool isAttacking;

        public float health;    
        public enum arena
        {
            arena1,arena2,arena3,arena4
        };

        public GameObject parallax;

        public arena aren = arena.arena1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //parallax.transform.position = new Vector3 (0,-66,0);
    }

    public void gameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    
    public void upgradeHealth(int h)
    {
        maxHealth += h;
        health = maxHealth;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().healthbar.setMaxHealth((int)health);

    }

    public void upgradeAttack()
    {

    }

}
