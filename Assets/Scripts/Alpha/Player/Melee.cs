/*
 * Colin Kintzinger
 * 04/02/24
 * Weapon parent class for the combat system.
 * 
 * CHANGE LOG
 * colin-4/02/24-Finished up on the code and added comments
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//derrived class from parent
public class Melee : Weapon
{

    public GameObject meleeLine;
    public GameObject bullet;
    protected new void Start()
    {
        //calls the start function from the parent class 
        base.Start();

        //sets the variables to the script component 
        meleeLine = aimTransform.GetChild(0).gameObject;
        playerStats = Resources.Load("PlayerStats") as PlayerStats;
        bullet = Resources.Load("MeleeShot") as GameObject;
    }
    public override void Attack()
    {
        //instantiates the melee attack
        GameObject bulletInst = Instantiate(bullet, aimTransform.position, Quaternion.Euler(0, 0, angle - 90));
        //if (timer >= attackTime)
        //{
        //    meleeLine.gameObject.SetActive(true);
        //    Debug.Log("true");
        //}
        //else
        //{
        //    meleeLine.gameObject.SetActive(false);
        //}

    }
}

