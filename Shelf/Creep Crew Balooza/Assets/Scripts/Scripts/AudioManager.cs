using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource levelMusic, gameOverMusic, winMusic;

    public AudioSource[] sfx;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        levelMusic.volume = .01f;
        levelMusic.Play();
    }

    void Update()
    {
        
    }

    public void PlayGameOver()
    {
        levelMusic.Stop();

        gameOverMusic.Play();
    }

    public void PLayLevelWin()
    {
        levelMusic.Stop();

        winMusic.Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }
}
