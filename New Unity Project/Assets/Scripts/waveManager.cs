using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public int waveNumber;
        public float timeLeft;

        [SerializeField]
        public GameObject[] enemies;
        public GameObject[] en1ref;
        public GameObject enemy;
        public int[] maxNumberofEnemies;

        public int[] enemiesAlive = { 0, 0, 0, 0 };

        void Start () {
            waveStart ();
            for (int i = 0; i < 4; i++) {
                spawnPoints[0][i] = spawnPointsArena1[i];
                spawnPoints[1][i] = spawnPointsArena2[i];
                spawnPoints[2][i] = spawnPointsArena3[i];
                spawnPoints[3][i] = spawnPointsArena4[i];
            }
        }

        // Update is called once per frame

        void FixedUpdate () {
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
            if (enemiesAlive[0] < maxNumberofEnemies[0] && playing && spawnPointsArena1[ch].GetComponent<spawnOverlap> ().canSpawn) {
                
                // int ch =1;

                switch (gameManager.Instance.aren) {
                    case gameManager.arena.arena1:
                        {
                            
                                switch (ch) {
                                    case 1:
                                        {

                                            en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena1[ch].transform.position, Quaternion.identity); //= Instantiate(enemies[0], spawnPointsArena2[ch].transform.position, Quaternion.identity);
                                            spawnPointsArena1[ch].GetComponent<spawnOverlap>().canSpawn = false;
                                            ch = (int) Random.Range (1.0f, 4.0f);

                                        }
                                        break;
                                    case 2:
                                        {
                                            en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena1[ch].transform.position, Quaternion.identity);
                                            spawnPointsArena1[ch].GetComponent<spawnOverlap>().canSpawn = false;
                                            ch = (int) Random.Range (1.0f, 4.0f);
                                        }
                                        break;
                                    case 3:
                                        {
                                            en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena1[ch].transform.position, Quaternion.identity);
                                            spawnPointsArena1[ch].GetComponent<spawnOverlap>().canSpawn = false;
                                            ch = (int) Random.Range (1.0f, 4.0f);
                                        }
                                        break;
                                    case 4:
                                        {
                                            en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena1[ch].transform.position, Quaternion.identity);
                                            spawnPointsArena1[ch].GetComponent<spawnOverlap>().canSpawn = false;
                                            ch = (int) Random.Range (1.0f, 4.0f);
                                        }
                                        break;
                                }
                            
                        }   break;

                            case gameManager.arena.arena2:
                                {
                                    switch (ch) {
                                        case 1:
                                            {
                                                en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena2[ch].transform.position, Quaternion.identity); //= Instantiate(enemies[0], spawnPointsArena2[ch].transform.position, Quaternion.identity);

                                                ch = (int) Random.Range (1.0f, 4.0f);
                                            }
                                            break;
                                        case 2:
                                            {
                                                en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena2[ch].transform.position, Quaternion.identity);
                                                ch = (int) Random.Range (1.0f, 4.0f);
                                            }
                                            break;
                                        case 3:
                                            {
                                                en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena2[ch].transform.position, Quaternion.identity);
                                                ch = (int) Random.Range (1.0f, 4.0f);
                                            }
                                            break;
                                        case 4:
                                            {
                                                en1ref[enemiesAlive[0]++] = Object.Instantiate (enemies[0], spawnPointsArena2[ch].transform.position, Quaternion.identity);
                                                ch = (int) Random.Range (1.0f, 4.0f);
                                            }
                                            break;
                                    }
                                }
                                break;
                        }

                }

            }
            void waveStart () {
                waveNumber++;
                for (int i = 0; i < walls.Length; i++) {
                    playing = true;
                    timeLeft = waveTime;
                    walls[i].GetComponent<BoxCollider2D> ().isTrigger = false;

                }
                
                maxNumberofEnemies[0] = (int) (4 + waveNumber * 1.5);
                if(maxNumberofEnemies[0]>25)
                maxNumberofEnemies[0] = 25;
                maxNumberofEnemies[1] = (int) (2 + waveNumber * 0.5);
                waveTime = 30 + waveNumber * 2;
            }

            void waveEnd () {

                for (int i = 0; i < en1ref.Length; i++) {
                    Destroy (en1ref[i]);
                }
                playing = false;
                enemiesAlive[0] = 0;
                timeLeft = waveTime;
                for (int i = 0; i < walls.Length; i++)
                    walls[i].GetComponent<BoxCollider2D> ().isTrigger = true;

            }
        }