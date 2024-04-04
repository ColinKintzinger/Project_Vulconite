/*
 * Dylan Rothbauer
 * 02/28/24
 * A simple script to attach to weapons
 * 
 * CHANGE LOG
 * 02/28/24 - Created script
 */
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public PlayerStats playerStats;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
    //        if (enemyHealth != null)
    //        {
    //            Debug.Log("EnemyHealth component retrieved!");
    //            enemyHealth.TakeDamage(playerStats.damage);
    //        } else
    //        {
    //            Debug.Log("EnemyHealth component NOT retrieved!");
    //        }
    //        //Destroy(collision.gameObject);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                Debug.Log("EnemyHealth component retrieved!");
                enemyHealth.TakeDamage(playerStats.damage);
            }
            else
            {
                Debug.Log("EnemyHealth component NOT retrieved!");
            }
            if (collision.gameObject.CompareTag("LootBox"))
            {
               Destroy(gameObject); 
            }
            //Destroy(collision.gameObject);
        }
    }
}
