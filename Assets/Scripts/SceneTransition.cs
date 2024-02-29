/*
 * Dylan Rothbauer
 * 02/21/24
 * 
 * Handles scene transtions on door
 * 
 * CHANGE LOG
 * Dylan - 02/21/24 - Added this new script for door functionality instead of player
 * Dylan - 02/27/24 - Added a bool to check if game objects with Enemy tag is dead (to avoid delegates)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToGoTo;
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            active = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && active)
        {
            SceneManager.LoadScene(sceneToGoTo);
        }
    }
}
