/*
 * Zachary Speckan
 * 03/25/24
 * Moves the subject to one of six locations.
 * 
 * boss - The subject
 * leftX - Leftmost location
 * middleX - Center location
 * rightX - Rightmost location
 * TopY - Topmost location
 * bottomY - Bottommost location
 * position - A location from a combined X and Y position
 * 
 * CHANGE LOG
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject boss;

    public float leftX = -12.0f;
    public float middleX = 0.0f;
    public float rightX = 12.0f;
    public float topY = 4.0f;
    public float bottomY = -4.0f;

    int position = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            MoveIt();
        }
    }

    public void MoveIt()
    {
        int prePosition = Random.Range(1, 7);

        if (prePosition == position)
        {
            MoveIt();
        }
        else
        {
            position = prePosition;
        }

        if (position == 1) //top left
        {
            transform.position = new Vector3(leftX, topY, transform.position.z);
        }
        else if (position == 2) //top middle
        {
            transform.position = new Vector3(middleX, topY, transform.position.z);
        }
        else if (position == 3) //top right
        {
            transform.position = new Vector3(rightX, topY, transform.position.z);
        }
        else if (position == 4) //bottom left
        {
            transform.position = new Vector3(leftX, bottomY, transform.position.z);
        }
        else if (position == 5) //bottom middle
        {
            transform.position = new Vector3(middleX, bottomY, transform.position.z);
        }
        else if (position == 6) //bottom right
        {
            transform.position = new Vector3(rightX, bottomY, transform.position.z);
        }
    }
}
