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
    public GameObject warning;

    public float leftX = -12.0f;
    public float middleX = 0.0f;
    public float rightX = 12.0f;
    public float topY = 4.0f;
    public float bottomY = -4.0f;

    int position = 0;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    MoveIt();
        //}
    }

    public IEnumerator MoveIt()
    {
        int prePosition = Random.Range(1, 7);

        if (prePosition == position)
        {
            StartCoroutine(MoveIt());
        }
        else
        {
            position = prePosition;
        }

        if (position == 1) //top left
        {
            warning.transform.position = new Vector3(leftX, topY, 0);
        }
        else if (position == 2) //top middle
        {
            warning.transform.position = new Vector3(middleX, topY, 0);
        }
        else if (position == 3) //top right
        {
            warning.transform.position = new Vector3(rightX, topY, 0);
        }
        else if (position == 4) //bottom left
        {
            warning.transform.position = new Vector3(leftX, bottomY, 0);
        }
        else if (position == 5) //bottom middle
        {
            warning.transform.position = new Vector3(middleX, bottomY, 0);
        }
        else if (position == 6) //bottom right
        {
            warning.transform.position = new Vector3(rightX, bottomY, 0);
        }

        yield return new WaitForSeconds(1.0f);
        boss.transform.position = warning.transform.position;
    }
}
