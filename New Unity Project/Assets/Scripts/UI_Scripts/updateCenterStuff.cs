using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class updateCenterStuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waveManager.Instance.playing && waveManager.Instance.timeLeft < 5)
            GetComponent<TextMeshProUGUI>().SetText("Wave Ends in " + ((int)waveManager.Instance.timeLeft).ToString());

        else if (!waveManager.Instance.playing && waveManager.Instance.timeLeft < 5)
            GetComponent<TextMeshProUGUI>().SetText("Next Wave in" + ((int)waveManager.Instance.timeLeft).ToString());
        else
            GetComponent<TextMeshProUGUI>().SetText("");
    }
}
