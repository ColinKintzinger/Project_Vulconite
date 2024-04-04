/*
 * Zachary Speckan
 * 03/29/24
 * Causes a random number of ice spikes to emerge from random spots in the ground.
 * 
 * warning - A warning symbol
 * spike - An ice spike
 * numberOfSpikes - The number of spikes that will spawn
 * 
 * xPosition - The x position of a spike
 * yPosition - The y position of a spike
 * spikePosition - An array of all spike locations
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IceSpikesRandom : MonoBehaviour
{
    public GameObject warning;
    public GameObject spike;
    int numOfSpikes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    numOfSpikes = Random.Range(10, 20);
        //    StartCoroutine(PrepareWarnings(numOfSpikes));
        //}
    }

    public IEnumerator PrepareWarnings(int num)
    {
        float xPosition = Random.Range(-14.8f, 14.8f);
        float yPosition = Random.Range(-4.5f, 5.0f);
        Vector3[] spikePosition = new Vector3[num];

        for (int i = 0; i < num; i++)
        {
            warning.transform.position = new Vector3(xPosition, yPosition, 0);
            spike.transform.position = new Vector3(xPosition, yPosition + 1, -0.1f);
            spikePosition[i] = spike.transform.position;
            //Debug.Log(warning.transform.position);
            Instantiate(warning, warning.transform.position, Quaternion.identity);
            xPosition = Random.Range(-14.8f, 14.8f);
            yPosition = Random.Range(-4.5f, 5.0f);
        }

        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < num; i++)
        {
            Instantiate(spike, spikePosition[i], Quaternion.identity);
        }
    }
}
