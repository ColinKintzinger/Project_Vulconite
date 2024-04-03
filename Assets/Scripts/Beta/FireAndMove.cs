/*
 * Zachary Speckan
 * 04/01/24
 * Teleports and fires a bullet at the player several times
 * 
 * teleport - Teleport script
 * fire - EnemyPredictShooting script
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAndMove : MonoBehaviour
{
    Teleport teleport;
    EnemyPredictShooting fire;

    // Start is called before the first frame update
    void Start()
    {
        teleport = GetComponent<Teleport>();
        fire = GetComponent<EnemyPredictShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(TeleSpam());
        }
    }

    public IEnumerator TeleSpam()
    {
        for (int i = 0; i < 3; i++)
        {
            teleport.MoveIt();
            yield return new WaitForSeconds(1.0f);
            fire.ShootToKill();
            yield return new WaitForSeconds(1.5f);
        }
    }
}
