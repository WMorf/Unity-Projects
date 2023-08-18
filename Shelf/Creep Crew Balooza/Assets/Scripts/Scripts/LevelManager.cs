using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToLoad = 4;

    public string nextlevel;

    public bool isPaused;

    public int currentCoins;

    private void Awake() 
    {
        instance = this;   
    }

    void Start()
    {
        Time.timeScale = 1f;

        UIcontroller.instance.coinText.text = currentCoins.ToString();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Cancel"))
        {
            PauseUnpause();
        }
    }

    public IEnumerator LevelEnd()
    {
        AudioManager.instance.PLayLevelWin();

        PlayerController.instance.canMove = false;

        UIcontroller.instance.StartFadeToBlack();

        yield return new WaitForSeconds(waitToLoad);

        SceneManager.LoadScene(nextlevel);

    }

    public void PauseUnpause()
    {
        if(!isPaused)
        {
            UIcontroller.instance.pauseMenu.SetActive(true);

            isPaused = true;

            Time.timeScale = 0f;
        }else
        {
            UIcontroller.instance.pauseMenu.SetActive(false);

            isPaused =false;

            Time.timeScale = 1f;
        }
    }

    public void GetCoins(int amount)
    {
        currentCoins += amount;

        UIcontroller.instance.coinText.text = currentCoins.ToString();
    }

    public void SpendCoins(int amount)
    {
        currentCoins -= amount;

        if(currentCoins < 0)
        {
            currentCoins = 0;
        }

        UIcontroller.instance.coinText.text = currentCoins.ToString();
    }
}
