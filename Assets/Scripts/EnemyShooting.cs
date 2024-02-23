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
                shoot();
            }
        }
    }

    // Shoots the bullet
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
