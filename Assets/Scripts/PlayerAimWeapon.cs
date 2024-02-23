using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    public GameObject meleeLine;
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        
    }

    private void Update()
    {
        // needs to pull a reference to the mouses in world position
        meleeAiming();
        meleAttack();
    }
    private void meleAttack()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("true");
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

