using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class updateWaveTimer : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().SetText(((int)waveManager.Instance.timeLeft).ToString());
    }
}
