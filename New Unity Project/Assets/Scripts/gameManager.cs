using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : Singleton<gameManager>
{
        public int money;    

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
        
    }
}
