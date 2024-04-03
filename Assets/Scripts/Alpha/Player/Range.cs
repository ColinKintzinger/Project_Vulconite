using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Range : Weapon
{
    public GameObject bullet;
    protected void Start()
    {
        
        base.Start();
        bullet = Resources.Load("Triangle", typeof(GameObject)) as GameObject;
        attackWeapon = Resources.Load("PlayerStats" )as PlayerStats ;
    }
    public override void Attack()
    {
        GameObject bulletInst = Instantiate(bullet, bulletSpawn.position, Quaternion.Euler(0, 0, angle - 90));

    }
}