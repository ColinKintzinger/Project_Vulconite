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
using UnityEditor.VersionControl;
using UnityEngine;

//derrived class from parent
public class Range : Weapon
{
    GameObject bullet;
    public string bulletInResorces = "Triangle";
    public string attackWeaponInResorces = "PlayerStats";

    protected void Start()
    {
        //calls the start function from the parent class
        base.Start();

        //sets the variables to the script component 
        bullet = Resources.Load(bulletInResorces, typeof(GameObject)) as GameObject;
        attackWeapon = Resources.Load(attackWeaponInResorces) as PlayerStats ;
    }
    //instantiates ranged bullet
    public override void Attack()
    {
        
        Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
        GameObject bulletInst = Instantiate(bullet, bulletSpawn.position+offset, Quaternion.Euler(0, 0, angle));

    }
   
}