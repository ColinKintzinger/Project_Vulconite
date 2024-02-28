/*
 * Colin Kintzinger
 * 2/20/2024
 * when enemy is hit with melee and or range attack it will disapear
 * 
 * CHANGE LOG
 * colin-2/26/24- added on trigger enter 2d function 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        
    }
}


