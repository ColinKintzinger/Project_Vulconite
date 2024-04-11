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
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
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

    private Animator movementAnimate;
    private SpriteRenderer render;
    private int direction = 0;
    // Start is called before the first frame update
    void Start()
    {
      movementAnimate = GetComponent<Animator>(); 
      render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.W))
        {
            direction = 1;
            setAnimation(false,1,true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = 3;
            setAnimation(false,3,true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = 2;
            setAnimation(false,2,true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = 4;
            setAnimation(true,2,true);
        }
        else if (direction==4 && !Input.GetKey(KeyCode.A))
        {
            setAnimation(true,0,false);
        }
        else
        {
            setAnimation(false,0,false);

        }

        void setAnimation(bool flip, int dInt, bool walking) {
            gameObject.GetComponent<SpriteRenderer>().flipX = flip;
            movementAnimate.SetInteger("Direction", dInt);
            movementAnimate.SetBool("isWalking", walking);
        }
        //if (Input.GetKey(KeyCode.S))
        //{
        //    movementAnimate.SetInteger("Direction", 3);
        //    //movementAnimate.SetBool("isWalking", true);
        //}
        //else
        //{
        //    movementAnimate.SetInteger("Direction", 0);
        //}
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
        }
    }

}
