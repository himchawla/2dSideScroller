using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthBarScript : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void setHealth(int health)
    {
        slider.value = health;
    }

    public void setMaxHealth(int h)
    {
        slider.maxValue = h;
        slider.value = h;
    }
}
