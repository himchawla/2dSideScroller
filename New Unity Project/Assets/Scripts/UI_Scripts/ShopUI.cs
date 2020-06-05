using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopUI : MonoBehaviour
{
    public GameObject Shop;
    public int counter = 2;
    public GameObject Health;
    public GameObject Attack;
    public GameObject Speed;


    public void showhideShop()
    {
        ++counter;
        if (counter % 2 == 1)
        {
            Shop.gameObject.SetActive(true);
           
        }
        else
        {
            Shop.gameObject.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Shop.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
       


        if (Input.GetButtonDown("B"))
        {
            showhideShop();
        }

        //Button UHealth = Health.GetComponent<Button>();
        //if (UHealth.onClick)
        //{
        //    upgradeHealth(5);
        //}

        //Button UAttack = Attack.GetComponent<Button>();
        //if (UAttack.onClick)
        //{
        //    upgradeAttack(2);
        //}

        //Button USpeed = Speed.GetComponent<Button>();
        //if (USpeed.onClick)
        //{
        //    upgradeSpeed(1);
        //}
    }





}
