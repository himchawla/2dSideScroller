using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class updatewaveEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (waveManager.Instance.waveBeat)
        {
            waveManager.Instance.waveBeat = false;
            if (waveManager.Instance.waveNumber < 4)
                GetComponent<TextMeshProUGUI>().SetText("You just beat wave " + waveManager.Instance.waveNumber);

            else
                GetComponent<TextMeshProUGUI>().SetText("You just beat wave the Final Wave" + waveManager.Instance.waveNumber);
        }
        else if(waveManager.Instance.timeLeft<(waveManager.Instance.waveTime-3))
            GetComponent<TextMeshProUGUI>().SetText("");





    }
}
