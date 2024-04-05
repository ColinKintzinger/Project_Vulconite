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

public class Weapon : MonoBehaviour
{
    protected Transform aimTransform;
    protected Transform bulletSpawn;

    public float fireDelay = 1f;
    public float attackTime = .5f;
    public float timer = 0;
    protected float angle;

    public PlayerStats attackWeapon;
    // Start is called before the first frame update
    protected void Start()
    {
        aimTransform = transform.Find("Aim");
        bulletSpawn = transform.Find("Aim");
        attackWeapon = Resources.Load("PlayerStats") as PlayerStats;

    }

    // Update is called once per frame
    void Update()
    {

        meleeAiming();
        //sets the delay so player can't spam the melee attack
        if (Input.GetMouseButton(0) && timer <= 0)
        {
            timer = fireDelay;
            Attack();
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime * 1;
            //Debug.Log(timer);
        }
    }
    //virtual method for attacking
    public virtual void Attack()
    {

    }
    //allows the player object to get the angle for the positioning of the melee object 
    private void meleeAiming()
    {
        Vector3 mousePosition = GetMouseWorldPositon();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
       // Debug.Log(aimTransform);
       // Debug.Log(angle);
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        // Debug.Log(angle);  
    }
    //these obtain the mouse position in the world position for tracking on the map 
    public static Vector3 GetMouseWorldPositon()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}

