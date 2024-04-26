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
    public AudioSource src;
    public AudioClip hurtClip;
    public AudioClip deathClip;

    private string SceneToLoad = "Win Screen";

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            src.clip = hurtClip;
            src.Play();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WeaponBullet"))
        {
            Destroy(collision.gameObject);
        }
    }

}
