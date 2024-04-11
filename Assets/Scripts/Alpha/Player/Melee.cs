/*
 * Colin Kintzinger
 * 04/02/24
 * Weapon parent class for the combat system.
 * 
 * CHANGE LOG
 * colin-4/02/24-Finished up on the code and added comments
 * Dylan - 04/11/24 - Added cooldown functions, cause unity hates me
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//derrived class from parent
public class Melee : Weapon
{
    public GameObject meleeLine;
    public float meleeCooldown = .5f;
    private bool canMelee = true;

    protected new void Start()
    {
        base.Start();
        meleeLine.SetActive(false);

    }

    public override void Attack()
    {
        if (canMelee)
        {
            canMelee = false;

            meleeLine.SetActive(true);

            float meleeDuration = 0.5f;
            Invoke("DeactivateMelee", meleeDuration);

            // Wait for the cooldown
            float cooldownDuration = 1f;
            Invoke("ResetCanMelee", cooldownDuration);
        }
    }

    private void DeactivateMelee()
    {
        meleeLine.SetActive(false);
    }

    private void ResetCanMelee()
    {
        canMelee = true;
    }
}



