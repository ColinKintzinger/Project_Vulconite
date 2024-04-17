/*
 * Dylan Rothbauer
 * 03/20/24
 * The Charm object - will be used for inheritance (hopefully)
 * 
 * CHANGE LOG
 * Dylan - 03/20/24 - Added a structure for different charms. Not yet functional
 * Dylan - 03/21/24 - Added more structure | Got feedback from Turner, inheritance looks like the way to go
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Charm : MonoBehaviour
{
    public string charmName;
    public GameObject pickupIndicator;
    private GameObject objectToFind;
    private TextMeshPro textMeshPro;
   

    // Start is called before the first frame update
    void Start()
    {
        objectToFind = transform.GetChild(1).gameObject;
        objectToFind.SetActive(false);
        textMeshPro = objectToFind.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void ApplyBuff(PlayerStats playerStats)
    {
        // A virtual fuction for children to override as needed
        
    }

    public void ShowIndicator(string text)
    {
        if (objectToFind != null)
        {
            textMeshPro.text = text;
            objectToFind.SetActive(true);
        } else
        {
            Debug.Log("PICKUPINDICATOR IS NULL");
        }
    }
    

}