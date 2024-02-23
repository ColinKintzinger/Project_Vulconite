using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    public GameObject meleeLine;
    private float fireDelay = 3.0f;
    private float timer=0;
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        
    }

    private void Update()
    {
        // needs to pull a reference to the mouses in world position
        meleeAiming();
        if (timer == 0)
        {
            meleAttack();
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime * 1;
        }

    }
    private void meleAttack()
    {
        
        if (Input.GetMouseButton(0) && timer <= 0)
        {
            showObject();
            timer = 3;
            Debug.Log("true");
        }

        //if (lastFiredMelee>0) { lastFiredMelee -= Time.deltaTime*1; }
        
    }
    private void showObject()
    {
        float timer = 1;
        while (timer > 1)
        {
            meleeLine.gameObject.SetActive(true);
            timer -= Time.deltaTime * 1;
        }
        meleeLine.gameObject.SetActive(false);
        return; 
    }
    private void meleeAiming()
    {
        Vector3 mousePosition = GetMouseWorldPositon();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        //Debug.Log(angle);
    }

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

