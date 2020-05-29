using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : Singleton<waveManager>
{
    
    // Start is called before the first frame update
    [SerializeField]
    public GameObject [] walls;
    public bool playing; 

    public int waveTime;
    public int waveNumber;

    public int timeLeft;

    [SerializeField]
    public GameObject [] enemies ;
    
    public int [] maxNumberofEnemies;
    
    private int enemiesAlive;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playing)
        {
            waveStart();
        }
        else waveEnd();
    }
    void waveStart()
    {
        for(int i =0; i < walls.Length; i++)
        {
            timeLeft = waveTime;
            walls[i].GetComponent<BoxCollider2D>().isTrigger = false;
            
        }
    }

    void waveEnd()
    {
        for(int i = 0; i < walls.Length; i++)
            walls[i].GetComponent<BoxCollider2D>().isTrigger = true;
        
        }
    }
