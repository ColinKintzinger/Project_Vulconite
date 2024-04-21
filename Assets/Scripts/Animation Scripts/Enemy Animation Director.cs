/* Animation Controller for the Enemies
 * Staton Otto and Colin 
 * Desc: Controls the enemy animation and displays movement for the enemy. (Most likely will need to 
 * adjust the attack to go after the player rather than its movement for it to actually animate the 
 * attack at the player).
 * ---- CHANGELOG ----
 * Staton Otto (2024/04/17) - Added a timer to allow the vectors to change between updates.
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationDirector : MonoBehaviour
{
    float timer = 0.01f;
    Vector3 newPosition = new Vector3(0, 0, 0);
    Vector3 oldPositon = new Vector3(0, 0, 0);
    bool isIdle = true;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            oldPositon = newPosition;
            newPosition = transform.position;
            if (newPosition == oldPositon)
            {
                angle = -90f;
                isIdle = true;
            }
            else
            {
                Vector3 targetVector = newPosition - oldPositon;
                angle = Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg;
                isIdle = false;
            }
            Debug.Log("Target Angle= " + angle);
            timer = 0.01f;
        }
        else {
            timer -= Time.deltaTime;
        }
    }
}
