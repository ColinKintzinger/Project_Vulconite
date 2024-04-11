/*
 * Dylan Rothbauer
 * 02/19/24
 * Standard PlayerController class that handles movement, collisions, etc.
 * 
 * CHANGE LOG
 * Dylan - 02/19/24 - Added onCollisionEnter2D function to get scene transitions working
 * Dylan - 02/21/24 - Refactored scene transtion to a door script in SceneTransition
 * Colin - 02/21/24 - added variables and some lines of code in the update for finding length between player and curser
 * Zach - 02/23/24 - Added restraints to player movement to prevent it from moving outside a certain range
 * Dylan - 02/27/24 - Added a destroy object in collider function to test scene transitions (needed a way to "kill" enemies)
 * Dylan - 02/28/24 - Changed Collider to include melee functionality in my scene
 * Dylan/Colin - 03/04/24 - polished code and spacing
 * Dylan - 03/05/24 - Added PlayerStats SerializedFeild to try ScriptableObjects
 * Colin - 04/02/24 - added more to the on collision for melee/range choice
 */
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{    
    public float horizontalInput;
    public float verticalInput;
    public float speed = 3.0f;
    public float xMovement = 10.0f;
    public float yMovement = 10.0f;
    //public GameObject meleeLine;

    [SerializeField]
    private PlayerStats playerStats; // Trying out ScriptableObjects

    private int damageToPlayer = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);

    }

    // Testing collision for delagate scene transition
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            // take damage
            playerStats.TakeDamage(damageToPlayer);

        } else if (collision.gameObject.CompareTag("Charm"))
        {
            playerStats.EquipCharm(collision.gameObject.GetComponent<Charm>());
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Weapon"))
        {
            Singleton.Instance.SetWeapon(collision.gameObject);
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            //playerStats.weapon = collision.gameObject.GetComponent<Range>();
            //playerStats.EquipWeapon(collision.gameObject);
            //Destroy(collision.gameObject);
        }
        //else if (collision.CompareTag("MeleeCollider"))
        //{
        //    // Set the colliding game object as a child of the player
            
        //    collision.transform.SetParent(transform.Find("Aim"));

        //    // Activate the melee weapon
        //    Transform meleeWeapon = transform.Find("Aim/Weapon");
        //    if (meleeWeapon != null)
        //    {
        //        meleeWeapon.gameObject.SetActive(true);
        //    }
        //    Singleton.Instance.SetWeapon(collision.gameObject);
        //}
    }

}
