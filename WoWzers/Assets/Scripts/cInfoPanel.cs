using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cInfoPanel : MonoBehaviour
{
    public Text reward, life, message;
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
            }
            catch { }
        }
        else
        {
            reward.text = "0";
            life.text = "0";
            message.text = "Oof";
        }
    }
}
