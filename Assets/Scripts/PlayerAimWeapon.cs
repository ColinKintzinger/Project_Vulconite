using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    private void Update()
    {
        // needs to pull a reference to the mouses in world position
        Vector3 mousePosition = GetMouseWorldPositon();

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

