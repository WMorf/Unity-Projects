using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dInfoPanel : MonoBehaviour
{
    // Clicking on an mob will populate this info panel with useful stats
    // Mob must possess ToolTip class

    public Text reward, life, message, timer, threshold;
    public dMobInfo mobInfo;

    void Update()
    {
        if (mobInfo != null)
        {
            try
            {
                reward.text = mobInfo.rewardScore.ToString();
                life.text = mobInfo.lifeTime.ToString();
                message.text = mobInfo.manager.stateCheck.stateMessage.ToString();
                timer.text = mobInfo.manager.stateCheck.timer.ToString();
                threshold.text = mobInfo.manager.stateCheck.threshold.ToString();
            }
            catch { }
        }
        else
        {
            reward.text = "0";
            life.text = "0";
            message.text = "Oof";
            timer.text = "0";
            threshold.text = "0";
        }
    }

    public void GetMob(dMobInfo script)
    {
        mobInfo = script;
    }
}
