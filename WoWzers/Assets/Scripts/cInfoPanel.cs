using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cInfoPanel : MonoBehaviour
{
    public Text reward, life;
    public bMob mobScript;

    public void GetMob(bMob script)
    {
        mobScript = script;
    }

    void Update()
    {
        if (mobScript != null)
        {
            try
            {
                reward.text = mobScript.rewardScore.ToString();
                life.text = mobScript.lifeTime.ToString();
            }
            catch { }
        }
        else
        {
            reward.text = "0";
            life.text = "0";
        }
    }
}
