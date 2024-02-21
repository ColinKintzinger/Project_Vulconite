using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private float leftBound = -25;
    private float upperBound = 6;
    private float lowerBound = -6;
    private float rightBound = 25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftBound || transform.position.y > upperBound 
            || transform.position.y < lowerBound || transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }
}
