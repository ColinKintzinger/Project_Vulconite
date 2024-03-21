/*
 * Dylan Rothbauer
 * 03/20/24
 * The Charm object - will be used for inheritance (hopefully)
 * 
 * CHANGE LOG
 * Dylan - 03/20/24 - Added a structure for different charms. Not yet functional
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm : MonoBehaviour
{
    string charmName;

   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}

public class DamageCharm : Charm
{
    public int damageBuff;


}

public class SpeedBuffCharm : Charm
{
    public float speedBuff;

}