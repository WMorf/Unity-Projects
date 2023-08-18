using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth;
    public int maxHealth;

    public GameObject hitEffect;

    public float damageInvincLength = 1f;
    private float invincCount;
    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth =  maxHealth;

        UIcontroller.instance.healthSlider.maxValue = maxHealth;
        UIcontroller.instance.healthSlider.value = currentHealth;
        UIcontroller.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCount > 0)
        {
            invincCount -= Time.deltaTime;

            if(invincCount <= 0)
            {
                PlayerController.instance.bodySR.color = new Color( PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, 1f);
            }
        }
    }


    //Player Hurt
    public void DamagePlayer()
    {
        if(invincCount <= 0)
        {

        currentHealth--;

        AudioManager.instance.PlaySFX(11);

        invincCount = damageInvincLength;

        PlayerController.instance.bodySR.color = new Color( PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, .5f);

        Instantiate(hitEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);

     //Player Death
        if(currentHealth <= 0)
        {
            PlayerController.instance.gameObject.SetActive(false);
            AudioManager.instance.PlaySFX(9);

            UIcontroller.instance.deathScreen.SetActive(true);

            AudioManager.instance.PlayGameOver();
        }

        //Healthbar
        UIcontroller.instance.healthSlider.value = currentHealth;
        UIcontroller.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        }
    }

    public void MakeInvincible(float length)
    {
        invincCount = length;
        PlayerController.instance.bodySR.color = new Color( PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, .5f);
    }

    public void HealPlayer(int healAmount)
    {

        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIcontroller.instance.healthSlider.value = currentHealth;
        UIcontroller.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount;

        UIcontroller.instance.healthSlider.maxValue = maxHealth;
        UIcontroller.instance.healthSlider.value = currentHealth;
        UIcontroller.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

}
