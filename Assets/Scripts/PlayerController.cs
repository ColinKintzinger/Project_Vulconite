/*
 * Dylan Rothbauer
 * 02/19/24
 * Standard PlayerController class that handles movement, collisions, etc.
 * 
 * CHANGE LOG
 * Dylan - 02/19/24 - Added onCollisionEnter2D function to get scene transitions working
 * Dylan - 02/21/24 - Refactored scene transtion to a door script in SceneTransition
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
    public Vector3 mousePos;
    public Vector3 target;
    public float angle;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        target= mousePos - transform.position;
        angle= Vector2.Angle(mousePos, transform.forward);
        Debug.Log("Trans.pos:" + transform.position);


        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.up *  verticalInput * Time.deltaTime * speed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
