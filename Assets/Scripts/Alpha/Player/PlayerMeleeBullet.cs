using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeBullet : MonoBehaviour
{
           private Rigidbody2D rb;
    public float speed = 10f;
    public float lifeTime = .2f;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed; 
        if (lifeTime < 0)
        { 
            Destroy(gameObject);
        }
        lifeTime -= Time.deltaTime * 1;

    }
}
