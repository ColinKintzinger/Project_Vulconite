/*
 * Dylan Rothbauer
 * 03/25/24
 * Speed charm script for unity to be happy
 * 
 * CHANGE LOG
 * Dylan - 03/25/24 - Created script
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCharm : Charm
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ApplyBuff(PlayerStats playerStats)
    {
        //base.applyBuff();
        float randomSpeedBuff = Random.Range(0.1f, 0.3f);
        playerStats.speed += randomSpeedBuff;

        // Show message on the UI Text object
        Debug.Log("Speed Charm Collected! Speed increased by " + randomSpeedBuff);
    }

}
