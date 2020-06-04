using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class waveManager : Singleton<waveManager> {

    // Start is called before the first frame update
    [SerializeField]
    public GameObject[] walls;
    public bool playing;
    [SerializeField]
    public GameObject[][] spawnPoints;
    public GameObject[][] cannonArena;
    public GameObject[] spawnPointsArena1;
    public GameObject[] cannonArena1;
    public GameObject[] spawnPointsArena2;
    public GameObject[] cannonArena2;
    public GameObject[] spawnPointsArena3;
    public GameObject[] cannonArena3;
    public GameObject[] spawnPointsArena4;
    public GameObject[] cannonArena4;
    public int waveTime;
    public float spawnDelay;
    private float spawnDel;
    public int waveNumber = 0;
    public float timeLeft;

    [SerializeField]
    public GameObject[] enemies;
    public GameObject[] en1ref;
    public GameObject enemy;
    public int[] maxNumberofEnemies;

    public int[] enemiesAlive = { 0, 0, 0, 0 };

    public int[] currEnemies;
    void Start () {
        waveStart ();
        for (int i = 0; i < 4; i++) {
            spawnPoints[0][i] = spawnPointsArena1[i];
            spawnPoints[1][i] = spawnPointsArena2[i];
            spawnPoints[2][i] = spawnPointsArena3[i];
            spawnPoints[3][i] = spawnPointsArena4[i];
        }
        spawnDel = spawnDelay;
    }

    // Update is called once per frame

    void FixedUpdate () {
        if(Input.GetButtonDown("Skip") && !playing)
        {
            if(timeLeft>5)
            timeLeft = 5;
        }
        if(playing && currEnemies[0] <=0 && enemiesAlive[0] == maxNumberofEnemies[0])
        waveEnd();
        spawnDel -= Time.deltaTime;
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
        } else if (playing) {
            waveEnd ();
        } else {
            waveStart ();
        }
    }

    void Update () {
        int ch = (int) Random.Range (1.0f, 4.0f);
        if (enemiesAlive[0] < maxNumberofEnemies[0] && playing && (spawnDel <= 0)) {
            spawnDel -= Time.deltaTime;

            // int ch =1;

            switch (gameManager.Instance.aren) {
                case gameManager.arena.arena1:
                    {

                        switch (ch) {
                            case 1:
                                {

                                    en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena1[ch].transform.position, Quaternion.identity); //= Instantiate(enemies[0], spawnPointsArena2[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;
                                    ch = (int) Random.Range (1.0f, 4.0f);

                                    currEnemies[0]++;
                                }
                                break;
                            case 2:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena1[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;
                                    ch = (int) Random.Range (1.0f, 4.0f);
                                    currEnemies[0]++;
                                }
                                break;
                            case 3:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena1[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;
                                    ch = (int) Random.Range (1.0f, 4.0f);
                                currEnemies[0]++;
                                }
                                break;
                            case 4:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena1[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;
                                    ch = (int) Random.Range (1.0f, 4.0f);
                                
                                currEnemies[0]++;
                                }
                                break;
                        }

                    }
                    break;

                case gameManager.arena.arena2:
                    {
                        switch (ch) {
                            case 1:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena2[ch].transform.position, Quaternion.identity); //= Instantiate(enemies[0], spawnPointsArena2[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;

                                    ch = (int) Random.Range (1.0f, 4.0f);
                               currEnemies[0]++;
                                }
                                break;
                            case 2:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena2[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;

                                    ch = (int) Random.Range (1.0f, 4.0f);
                                currEnemies[0]++;
                                }
                                break;
                            case 3:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena2[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;

                                    ch = (int) Random.Range (1.0f, 4.0f);
                                currEnemies[0]++;
                                }
                                break;
                            case 4:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena2[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;

                                    ch = (int) Random.Range (1.0f, 4.0f);
                                currEnemies[0]++;
                                }
                                break;
                        }
                    }
                    break;

                case gameManager.arena.arena3:
                    {
                        switch (ch)
                        {
                            case 1:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate(enemies[0], spawnPointsArena3[ch].transform.position, Quaternion.identity); //= Instantiate(enemies[0], spawnPointsArena3[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;

                                    ch = (int)Random.Range(1.0f, 4.0f);
                                    currEnemies[0]++;
                                }
                                break;
                            case 2:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate(enemies[0], spawnPointsArena3[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;

                                    ch = (int)Random.Range(1.0f, 4.0f);
                                    currEnemies[0]++;
                                }
                                break;
                            case 3:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate(enemies[0], spawnPointsArena3[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;

                                    ch = (int)Random.Range(1.0f, 4.0f);
                                    currEnemies[0]++;
                                }
                                break;
                            case 4:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate(enemies[0], spawnPointsArena3[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;

                                    ch = (int)Random.Range(1.0f, 4.0f);
                                    currEnemies[0]++;
                                }
                                break;
                        }
                    }
                    break;

                case gameManager.arena.arena4:
                    {
                        switch (ch)
                        {
                            case 1:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate(enemies[0], spawnPointsArena4[ch].transform.position, Quaternion.identity); //= Instantiate(enemies[0], spawnPointsArena4[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;

                                    ch = (int)Random.Range(1.0f, 4.0f);
                                    currEnemies[0]++;
                                }
                                break;
                            case 2:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate(enemies[0], spawnPointsArena4[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;

                                    ch = (int)Random.Range(1.0f, 4.0f);
                                    currEnemies[0]++;
                                }
                                break;
                            case 3:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate(enemies[0], spawnPointsArena4[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;

                                    ch = (int)Random.Range(1.0f, 4.0f);
                                    currEnemies[0]++;
                                }
                                break;
                            case 4:
                                {
                                    en1ref[enemiesAlive[0]++] = Object.Instantiate(enemies[0], spawnPointsArena4[ch].transform.position, Quaternion.identity);
                                    spawnDel = spawnDelay;

                                    ch = (int)Random.Range(1.0f, 4.0f);
                                    currEnemies[0]++;
                                }
                                break;
                        }
                    }
                    break;
            }

        }

    }
    void waveStart () {
          foreach(GameObject i in GameObject.FindGameObjectsWithTag("Portal"))
        i.GetComponent<SpriteRenderer>().enabled = false;

        gameManager.Instance.health = 100;
        if (waveNumber < 4)
            waveNumber++;
        else
            waveNumber = 4;
        for (int i = 0; i < walls.Length; i++) {
            playing = true;
            timeLeft = waveTime;
            walls[i].GetComponent<BoxCollider2D> ().isTrigger = false;

            switch (gameManager.Instance.aren)
            {
                case gameManager.arena.arena1:
                    {
                        arenaManager.Instance.arena1Begin();
                    }
                    break;
                case gameManager.arena.arena2:
                    {
                        arenaManager.Instance.arena2Begin();
                    }
                    break;
                case gameManager.arena.arena3:
                    {
                        arenaManager.Instance.arena3Begin();
                    }
                    break;
                case gameManager.arena.arena4:
                    {
                        arenaManager.Instance.arena4Begin();
                    }
                    break;
            }

            }

        maxNumberofEnemies[0] = (int) (4 + waveNumber * 1.5);
        if (maxNumberofEnemies[0] > 25)
            maxNumberofEnemies[0] = 25;
        maxNumberofEnemies[1] = (int) (2 + waveNumber * 0.5);
        waveTime = (int)(60 + waveNumber * 7.5f);
    }

    void waveEnd () {
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Portal"))
            i.GetComponent<SpriteRenderer>().enabled = true;
        for (int i = 0; i < en1ref.Length; i++) {
            Destroy (en1ref[i]);
        }
        playing = false;
        enemiesAlive[0] = 0;
        currEnemies[0] = 0;
        timeLeft = waveTime;
        for (int i = 0; i < walls.Length; i++)
            walls[i].GetComponent<BoxCollider2D> ().isTrigger = true;

    }
}