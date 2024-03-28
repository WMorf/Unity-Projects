using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cInfoPanel : MonoBehaviour
{
    public Text reward, life, message, timer, threshold;
    public cMobInfo mobScript;

    public void GetMob(cMobInfo script)
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
                message.text = mobScript.manager.stateMessage.ToString();
                timer.text = mobScript.manager.timer.ToString();
                threshold.text = mobScript.manager.threshold.ToString();
            }
            catch { }
        }
        else
        {
            reward.text = "0";
            life.text = "0";
            message.text = "Oof";
            timer.text ="0";
            threshold.text = "0";
        }
    }
}
