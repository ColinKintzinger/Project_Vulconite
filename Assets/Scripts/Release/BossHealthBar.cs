using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    public float startingHealth = 100.0f;
    public float currentHealth = 100.0f; //playerStats.health;
    private float scaleAdjustment;
    private float basePosition;
    private float baseYPosition;

    // Start is called before the first frame update
    void Start()
    {
        scaleAdjustment = transform.localScale.x / startingHealth;
        basePosition = transform.localPosition.x;
        baseYPosition = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        //need to correct the positioning of the transform.position
        transform.localScale = new Vector3(currentHealth * scaleAdjustment, baseYPosition, 0f);
        float positionXAdjustment = (currentHealth * scaleAdjustment - startingHealth * scaleAdjustment) / 2;
        transform.localPosition = new Vector3(basePosition + positionXAdjustment, 0, 1);
    }
}
