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
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    
    public float horizontalInput;
    public float verticalInput;
    public float speed = 3.0f;
    public float xMovement = 10.0f;
    public float yMovement = 10.0f;
    public GameObject meleeLine;


    //public Vector3 target;
    //public Vector3 worldPos;
    //public float angle;
    //public Vector3 playerPos;
    //public GameObject meleeCircle;


    // Start is called before the first frame update
    void Start()
    {
        //meleeCircle= GetComponent<GameObject>();
       

    }

    // Update is called once per frame
    void Update()
    {
        //worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //playerPos = transform.position;
        //target = worldPos - playerPos;
        //target = target.normalized;
        //angle = (Mathf.Atan(target.y / target.x) * 180 / Mathf.PI);
        //Debug.Log("Trans.pos:" + transform.position);

        //meleeCircle.transform.position = new Vector3(target.x, target.y, 0);
        //meleeCircle.transform.rotation = new Quaternion(0, 0, angle, 0).normalized;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        if (transform.position.x < -xMovement)
        {
            transform.position = new Vector3(-xMovement, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xMovement)
        {
            transform.position = new Vector3(xMovement, transform.position.y, transform.position.z);
        }

        transform.Translate(Vector3.up *  verticalInput * Time.deltaTime * speed);
        if (transform.position.y < -yMovement)
        {
            transform.position = new Vector3(transform.position.x, -yMovement, transform.position.z);
        }
        if (transform.position.y > yMovement)
        {
            transform.position = new Vector3(transform.position.x, yMovement, transform.position.z);
        }

    }

    // testing collision for delagate scene transition
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // take damage
        }
    }

}
