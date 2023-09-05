using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_MenuController : MonoBehaviour
{
    public SceneLoader loader;

    public void LoadNextLevel()
    {
        loader.LoadSceneName("MissileLevel01");
    }

    public void RestartGame()
    {
        loader.LoadSceneName("MissileStartScreen");
    }

    public void MainMenu()
    {
        loader.LoadMainMenu();
    }

}