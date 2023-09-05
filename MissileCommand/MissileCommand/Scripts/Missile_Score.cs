using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Missile_Score : MonoBehaviour
{
    
    public static Missile_Score Instance;
    public TMP_Text scoreboard;
    public int score;


    public void ScoreMissile()
    {
        score += 100;
    } 

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreboard.text = string.Format("Score: " + score);
    }
}
