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
    public float speedBuff = .5f;

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
        playerStats.speed += speedBuff;
    }

}
