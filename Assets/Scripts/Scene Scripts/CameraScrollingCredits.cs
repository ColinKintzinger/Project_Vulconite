using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrollingCredits : MonoBehaviour
{

    public float cameraTopBound = 0;
    public float creditsBound = -23.8f;
    public float cameraBotBound = -33.8f;
    public int speed = 2;
    public int viewSpeed = 1;
    public float timer = 5f;

    private Vector3 currentCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentCameraPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0 && currentCameraPosition.y > creditsBound)
        {
            currentCameraPosition.y -= Time.deltaTime * speed;
            transform.position = currentCameraPosition;
        }
        else if (timer <= 0 && currentCameraPosition.y > cameraBotBound) {
            currentCameraPosition.y -= Time.deltaTime * viewSpeed;
            transform.position = currentCameraPosition;
        }
        else if (timer > 0)
            timer -= Time.deltaTime;
    }
}
