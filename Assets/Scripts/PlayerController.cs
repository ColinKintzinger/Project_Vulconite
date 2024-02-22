/*
 * Dylan Rothbauer
 * 02/19/24
 * Standard PlayerController class that handles movement, collisions, etc.
 * 
 * CHANGE LOG
 * Dylan - 02/19/24 - Added onCollisionEnter2D function to get scene transitions working
 * Dylan - 02/21/24 - Refactored scene transtion to a door script in SceneTransition
 * Colin - 02/21/24 - added variables and some lines of code in the update for finding length between player and curser 
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
        transform.Translate(Vector3.up *  verticalInput * Time.deltaTime * speed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
