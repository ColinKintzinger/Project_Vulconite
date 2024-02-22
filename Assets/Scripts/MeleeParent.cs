/*
 * Colin Kintzinger
 * 02/21/24
 * 
 * 
 * CHANGE LOG
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeParent : MonoBehaviour
{
    public Vector2 PointerPosition {  get; set; }
    // Start is called before the first frame update
    public Vector2 mousePos;
    void Start()
    {
        mousePos = Input.mousePosition; 
    }

    // Update is called once per frame
    void Update()
    {
      //transform.up = (PointerPosition-(Vector2)transform.position).normalized;  
    }
}
