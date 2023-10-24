using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3, score = 0;
    [SerializeField] Text scoreText, livesText;

    [SerializeField] Image[] hearts;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void AddToScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void ProccessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            RestGame();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        UpdateHearts();
        livesText.text = playerLives.ToString();
    }

    public void AddToLives()
    {
        playerLives++;

        if(playerLives >= 3)
        {
            playerLives = 3;
        }
        UpdateHearts();

        livesText.text = playerLives.ToString();
    }

    private void UpdateHearts()
    {
        for(int i=0; i < hearts.Length; i++)
        {
            if (i < playerLives)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void RestGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
