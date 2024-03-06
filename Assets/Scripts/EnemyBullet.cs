/*
 * Zachary Speckan
 * 02/23/24
 * Sends a bullet towards the player's current location
 * 
 * force - How fast the bullet will fly
 * velocity - Bullet's velocity
 * velocitySet - If the velocity has already been set
 * 
 * CHANGE LOG
 * Zach - 02/23/24 - Added comments.
 * Zach - 03/06/24 - Now compatible with predictive aiming.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    public Rigidbody2D rb;
    public float force;
    private Vector2 velocity;
    private bool velocitySet = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");


        // Sends bullet towards player's location
        Debug.Log("bullet start");
        Vector3 direction = player.transform.position - transform.position;
        if (velocitySet)
        {
            rb.velocity = velocity;
        }
        else
        {
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        }

        // Rotates bullet so it faces the player
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVelocity(Vector2 theVelocity)
    {
        velocity = theVelocity;
        velocitySet = true;
    }
}
