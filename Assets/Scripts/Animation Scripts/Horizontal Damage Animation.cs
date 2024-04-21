/* Horizontal Damage Animator
 * Otto
 * Desc: General Purpose Animator for when something takes damage.
 * ---- CHANGELOG ----
 * Otto (20240417) Added modded code from the vertical float animator and a cycles counter.
 * Otto (20240417) Added a speed adjuster for speeding up the animation.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalDamageAnimation : MonoBehaviour
{
    public int cycles = 5;
    public int speed = 3;
    public float timer = 1;
    public float horizontalMovement = .005f;
    
    private int completedCycles = 0;
    // Update is called once per frame
    void Update()
    {
        float floaterVar = Mathf.Sin(timer * Mathf.PI) * horizontalMovement;
        transform.position += new Vector3(floaterVar, 0, 0);
        if (timer < 0 && completedCycles < cycles)
        {
            timer = 2;
            completedCycles += 1;
        }
        else if (completedCycles > cycles) { 
            //kill this script
        }
        timer -= Time.deltaTime*speed;
    }
}
