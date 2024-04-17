using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float floaterVar = Mathf.Sin(timer*Mathf.PI)*.005f;
        //Debug.Log("floaterVar= " +floaterVar);
        transform.position += new Vector3(0,floaterVar,0);
        if (timer < 0) {
            timer = 2;
        }
        timer -= Time.deltaTime;
    }
}
