/*
 * Zachary Speckan
 * 03/06/24
 * Shoots a bullet at the player's future position.
 * 
 * targetingDistance - Max distance the enemy will shoot the player at
 * targetingTimer - How long the enemy will wait until firing another bullet
 * 
 * CHANGE LOG
 * Zach - 03/06/24 - Added comments and made predictive aiming work properly.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class EnemyPredictShooting : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;
    public GameObject target;

    public float targetingDistance = 25.0f;
    public float targetingTimer = 2.0f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(projectile);
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the distance the player is from the enemy
        float distance = Vector2.Distance(transform.position, target.transform.position);
        Debug.Log(distance);

        // Checks if the player is close enough
        if (distance < targetingDistance)
        {
            timer += Time.deltaTime;

            // Checks if enough time has passed
            if (timer > targetingTimer)
            {
                timer = 0;
                ShootToKill();
            }
        }
    }

    //Shoots towards the player's future position.
    void ShootToKill()
    {
        var instance = Instantiate(projectile, transform.position, quaternion.identity);
        var targetVelocity = target.GetComponent<Rigidbody2D>().velocity;
        var projectileBody = instance.GetComponent<EnemyBullet>();
        if (InterceptionDirection(target.transform.position, transform.position, targetVelocity, projectileSpeed, out var direction))
        {
            projectileBody.setVelocity(direction * projectileSpeed);
        }
        else
        {
            projectileBody.setVelocity((target.transform.position - transform.position).normalized * projectileSpeed);
        }

    }

    //Predicts the path the player will take.
    public bool InterceptionDirection(Vector2 playerPosition, Vector2 enemyPosition, Vector2 playerVelocity, float bulletSpeed, out Vector2 result)
    {
        var distanceBetween = enemyPosition - playerPosition;
        var magDistanceBetween = distanceBetween.magnitude;
        var angleTurned = Vector2.Angle(distanceBetween, playerVelocity) * Mathf.Deg2Rad;
        var magPlayerVelo = playerVelocity.magnitude;
        var velocityRatio = magPlayerVelo / bulletSpeed;
        if (MyMath.SolveQuadratic(1 - velocityRatio * velocityRatio, 2 * velocityRatio * magDistanceBetween * Mathf.Cos(angleTurned), -(magDistanceBetween * magDistanceBetween), out var root1, out var root2) == 0)
        {
            Debug.Log("Didn't work.");
            result = Vector2.zero;
            return false;
        }
        var bulletDistance = Mathf.Max(root1, root2);
        var t = bulletDistance / bulletSpeed;
        var c = playerPosition + playerVelocity * t;
        result = (c - enemyPosition).normalized;
        return true;
    }
}

//Solves quadratic equation.
public class MyMath
{
    public static int SolveQuadratic(float a, float b, float c, out float root1, out float root2)
    {
        var discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            root1 = Mathf.Infinity;
            root2 = -root1;
            return 0;
        }
        root1 = (-b + Mathf.Sqrt(discriminant)) / (2 * a);
        root2 = (-b - Mathf.Sqrt(discriminant)) / (2 * a);
        return discriminant > 0 ? 2 : 1;
    }
}
