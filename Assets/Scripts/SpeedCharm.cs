/*
 * Dylan Rothbauer
 * 03/25/24
 * Speed charm script for unity to be happy
 * 
 * CHANGE LOG
 * Dylan - 03/25/24 - Created script
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedCharm : Charm
{
    public GameObject pickupIndicatorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ApplyBuff(PlayerStats playerStats)
    {
        //base.applyBuff();
        float randomSpeedBuff = Random.Range(0.05f, 0.15f);
        playerStats.speed += (playerStats.speed * randomSpeedBuff);

        // Show message on the UI Text object
        Debug.Log("Speed Charm Collected! Speed increased by " + (100 * randomSpeedBuff) + "percent");
        string text = "Speed Charm Collected! Speed increased by " + System.Math.Round(100 * randomSpeedBuff, 2) + "%";

        ShowIndicator(text);
        //pickupIndicator.GetComponent<TextMeshPro>().SetText(text);
        //pickupIndicator.GetComponent<TextMeshPro>().text = text;
        //Instantiate(pickupIndicator, transform);

        //GameObject pickupIndicator = Instantiate(pickupIndicatorPrefab, transform.position, Quaternion.identity, transform);
        //GameObject pickupIndicator = Instantiate(pickupIndicatorPrefab, transform);
        //Debug.Log(pickupIndicator.transform.position);
        //pickupIndicator.GetComponent<TextMeshPro>().text = text;

        //Destroy(pickupIndicator, 2f);
    }

}
