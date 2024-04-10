/*
 * Colin Kintzinger
 * 04/02/24
 * Weapon parent class for the combat system.
 * 
 * CHANGE LOG
 * colin-4/02/24-Finished up on the code and added comments
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//derrived class from parent
public class Melee : Weapon
{
    public GameObject meleeLine;
<<<<<<< Updated upstream
    public float meleeCooldown = .5f;
    private bool canMelee = true;

=======
>>>>>>> Stashed changes
    protected new void Start()
    {
        base.Start();
<<<<<<< Updated upstream
        meleeLine.SetActive(false);
=======
>>>>>>> Stashed changes
    }

    public override void Attack()
    {
<<<<<<< Updated upstream
        if (canMelee)
        {
            canMelee = false;

            meleeLine.SetActive(true);

            float meleeDuration = 0.1f;
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
=======
        Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
        //Instantiate(meleeLine, bulletSpawn.position + offset, Quaternion.Euler(0, 0, angle));
>>>>>>> Stashed changes
    }
}



