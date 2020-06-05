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
        public bool isPaused = false;
        public float health;
    public bool gameOverr;
    public float gameOverTimer = 2.0f;   

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
        gameOverTimer -= Time.deltaTime;
        if(gameOverr && (gameOverTimer<=0))
        {
            SceneManager.LoadScene("GameOver");

        }

        //parallax.transform.position = new Vector3 (0,-66,0);

        if(Input.GetKeyDown("pause"))
        {
            if(!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0;
                GameObject.FindGameObjectWithTag("pauseMenu").SetActive(true);
            }

            if (isPaused)
            {
                isPaused = false;
                Time.timeScale = 1;
                GameObject.FindGameObjectWithTag("pauseMenu").SetActive(false);
            }

        }
    }

    public void gameOver()
    {
        gameOverTimer = 2.0f;
        gameOverr = true;
   //     SceneManager.LoadScene("GameOver");
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

    public void mainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void resume()
    {
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("pauseMenu").SetActive(false);
    }

}
