/*
 * Dylan Rothbauer
 * 03/25/24
 * Damage charm script for unity to be happy
 * 
 * CHANGE LOG
 * Dylan - 03/25/24 - Created script
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class DamageCharm : Charm
{
    public GameObject pickupIndicatorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //pickupIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void ApplyBuff(PlayerStats playerStats)
    {
        //base.applyBuff();
        float randomDamageBuff = Random.Range(0.05f, 0.15f);
        playerStats.damage += (playerStats.damage * randomDamageBuff);

        Debug.Log("Damage Charm Collected! Damage increased by " + (100 * randomDamageBuff) + "percent");
        string text = "Damage Charm Collected!\n Damage increased by " + System.Math.Round(100 * randomDamageBuff, 2) + "%";

        //pickupIndicator.GetComponent<TextMeshPro>().SetText(text);
        //Instantiate(pickupIndicator, transform);

        GameObject pickupIndicator = Instantiate(pickupIndicatorPrefab, transform.position, Quaternion.identity, transform);
        pickupIndicator.GetComponent<TextMeshPro>().text = text;

        Destroy(pickupIndicator, 3f);

    }

}
