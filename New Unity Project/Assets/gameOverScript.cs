using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    public void toMainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }
    public void toGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
