/*
 * Colin Kintzinger
 * 2/20/2024
 * Player melee and can also be used for ranged attack through refactoring
 * 
 * CHANGE LOG
 * colin-2/27/24- commented code and refactored to get rid of hard coded values
 * otto-3/3/24 - tried adjusting the attack duration and frequency with the values. did not work.
 * Dylan - 03/06/24 - Got rid of OnTrigger function, it wasn't doing anything
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    public GameObject meleeLine;
    public float fireDelay = 1f;
    public float attackTime = .5f;
    private float timer=0;
    
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    private void Update()
    {
        // Needs to pull a reference to the mouses in world position
        meleeAiming();
        meleAttack();
        // Sets the delay so player can't spam the melee attack
        if (Input.GetMouseButton(0) && timer <= 0)
        {
            timer=fireDelay;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime * 1;
        }

    }
    // Allows the melee object to apear and then disapear acording to the timer
    private void meleAttack()
    {
        
        if (timer>=attackTime)
        {
            meleeLine.gameObject.SetActive(true);
        }
        else
        {
            meleeLine.gameObject.SetActive(false);
        }
        
    }
    private void meleeAiming()
    {
        Vector3 mousePosition = GetMouseWorldPositon();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
    // These obtain the mouse position in the world position for tracking on the map 
    public static Vector3 GetMouseWorldPositon() {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ() {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

}

