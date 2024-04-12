/*
 * Dylan Rothbauer
 * 03/20/24
 * A script to apply to each LootBox in the transition rooms. Will randomly spawn a charm once destroyed
 * 
 * CHANGE LOG
 * Dylan - 03/20/24 - Added collider2D function and RevealCharm(). Doesn't work with charmPrefab array yet.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    public int collisionCount = 0;
    public int collisionCountThreshold = 3;
    //public GameObject charmTest;
    public GameObject[] charmPrefabs;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WeaponBullet"))
        {
            collisionCount++;
            animator.SetInteger("Collision Count", collisionCount);
            Destroy(collision.gameObject);

            if (collisionCount >= collisionCountThreshold)
            {
                if (gameObject.CompareTag("LootBox"))
                {
                    RevealCharm();
                }
                //charm.GetComponent<Charm>().RevealCharm(charm);
                Destroy(gameObject);
            }
        }
    }

    public void RevealCharm()
    {
        int randomIndex = Random.Range(0, charmPrefabs.Length);
        GameObject charmPrefab = charmPrefabs[randomIndex];
        Instantiate(charmPrefab, transform.position, Quaternion.identity);

        //Instantiate(charmTest, transform.position, Quaternion.identity);
        collisionCount = 0;
    }

}
