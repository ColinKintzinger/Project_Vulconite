/*
 * Zachary Speckan
 * 02/23/24
 * Shoots a bullet at the player.
 * 
 * targetingDistance - Max distance the enemy will shoot the player at
 * targetingTimer - How long the enemy will wait until firing another bullet
 * bullet - The bullet prefab
 * bulletPos - Where the bullet will respawn at
 * 
 * CHANGE LOG
 * Zach - 02/23/24 - Added comments.
 * Zach - 02/29/24 - Bullets can predict where the player will be
 * Dylan/Colin - 03/04/24 - changed call from "shoot" to "Shoot" to stay consistant
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //used to modify the distance aquisition and consistency of the shots
    public float targetingDistance = 25.0f;
    public float targetingTimer = 2.0f;

    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the distance the player is from the enemy
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        // Checks if the player is close enough
        if (distance < targetingDistance)
        {
            timer += Time.deltaTime;

            // Checks if enough time has passed
            if (timer > targetingTimer)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    // Shoots the bullet
    void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    //public bool InterceptionDirection(Vector2 a, Vector2 b, Vector2 vA, float sB, out Vector2 result)
    //{
    //    var aToB = b - a;
    //    var dC = aToB.magnitude;
    //    var alpha = Vector2.Angle(aToB, vA) * Mathf.Deg2Rad;
    //    var sA = vA.magnitude;
    //    var r = sA / sB;
    //    if (MyMath.SolveQuadratic(1 - r * r, 2 * r * dC * Mathf.Cos(alpha), -(dC * dC), out var root1, out var root2) == 0)
    //    {
    //        result = Vector2.zero;
    //        return false;
    //    }
    //    var dA = Mathf.Max(root1, root2);
    //    var t = dA / sB;
    //    var c = a + vA * t;
    //    result = (c - b).normalized;
    //    return true;
    //}
}

//public class MyMath
//{
//    public static int SolveQuadratic(float a, float b, float c, out float root1, out float root2)
//    {
//        var discriminant = b * b - 4 * a * c;
//        if (discriminant < 0)
//        {
//            root1 = Mathf.Infinity;
//            root2 = -root1;
//            return 0;
//        }
//        root1 = (-b + Mathf.Sqrt(discriminant)) / (2 * a);
//        root2 = (-b - Mathf.Sqrt(discriminant)) / (2 * a);
//        return discriminant > 0 ? 2 : 1;
//    }
//}
