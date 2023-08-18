using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public GameObject buyMessage;

    private bool inBuyZone;

    public bool isHealthPot, isHealthBoost, isWep;

    public int tokenCost;

    public int boostAmount;

    public GameObject useEffect;
    public int pickupSound;

    void Start()
    {
        
    }

    void Update()
    {
        if(inBuyZone)
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Select"))
            {
                    if(LevelManager.instance.currentCoins >= tokenCost)
                    {
                        LevelManager.instance.SpendCoins(tokenCost);

                        if(isHealthPot)
                        {
                            HealthManager.instance.HealPlayer(HealthManager.instance.maxHealth);
                        }

                        if(isHealthBoost)
                        {
                            HealthManager.instance.IncreaseMaxHealth(boostAmount);
                        }

                        Instantiate(useEffect, transform.position, transform.rotation);

                        gameObject.SetActive(false);
                        inBuyZone = false;
                    }else
                    {
                        AudioManager.instance.PlaySFX(19);
                    }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            buyMessage.SetActive(true);

            inBuyZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            buyMessage.SetActive(false);

            inBuyZone = false;
        }
    }
}
