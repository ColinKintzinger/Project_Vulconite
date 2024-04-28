using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public delegate void EnemyHealthDelegate();
    public EnemyHealthDelegate takeDamage;
    public float maxHealth = 100.0f;
    public float currentHealth;
    public float visualDamageTimer = 1;
    public Color dmgColor = new Color(0 / 255, 0 / 255, 0 / 255);
    public AudioSource src;
    public AudioClip hurtClip;
    public AudioClip deathClip;
    public string SceneToLoad = "Win Screen";

    private float horizontalMovement = .01f;
    private int cycles = 5;
    private int completedCycles = 0;
    private int speed = 3;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        visualizeDamage(timer, dmgColor);



    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //Debug.Log(currentHealth);
        if (takeDamage != null) {
            takeDamage();
        }
        if (currentHealth <= 0.0f)
        {
            src.clip = deathClip;
            src.Play();
            Destroy(gameObject);
            if (gameObject.CompareTag("Boss")) {
                SceneManager.LoadScene(SceneToLoad);
            }
        }
        else
        {
            completedCycles = 0;
            src.clip = hurtClip;
            src.Play();
            timer = 2;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WeaponBullet"))
        {
            Destroy(collision.gameObject);
        }
    }


    public void visualizeDamage(float timer, Color color) {
        float horizontalMovement = .01f;
        float floaterVar = Mathf.Sin(timer * Mathf.PI) * horizontalMovement;
        transform.position += new Vector3(floaterVar, 0, 0);
        if (timer <= 0 && completedCycles < cycles)
        {
            timer = 2;
            completedCycles += 1;
        }
        timer -= Time.deltaTime;
    }
}
