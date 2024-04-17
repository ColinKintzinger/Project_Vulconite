using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationDirector : MonoBehaviour
{
    Vector3 newPosition = new Vector3(0, 0, 0);
    Vector3 oldPositon = new Vector3(0, 0, 0);
    bool isIdle = true;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        oldPositon = newPosition;
        newPosition = transform.position;
        if (newPosition == oldPositon)
        {
            angle = -90f;
            isIdle = true;
        }
        else {
            Vector3 targetVector =  newPosition - oldPositon;
            angle = Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg;
            isIdle = false;
        }
        Debug.Log("Target Angle= " + angle);
    }
}
