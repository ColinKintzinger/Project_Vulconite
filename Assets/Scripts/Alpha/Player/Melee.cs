using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{

    public GameObject meleeLine;
    public GameObject bullet;
    protected void Start()
    {
        base.Start();
        meleeLine = aimTransform.GetChild(0).gameObject;
        attackWeapon = Resources.Load("PlayerStats") as PlayerStats;
        bullet = Resources.Load("MeleeShot") as GameObject;
    }
    public override void Attack()
    {
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

