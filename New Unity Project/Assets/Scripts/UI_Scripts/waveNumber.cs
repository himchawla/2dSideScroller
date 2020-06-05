using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class waveNumber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waveManager.Instance.waveNumber<4)
        GetComponent<TextMeshProUGUI>().SetText("Wave " + waveManager.Instance.waveNumber.ToString());
        else
        GetComponent<TextMeshProUGUI>().SetText("Wave Final" );

    }
}
