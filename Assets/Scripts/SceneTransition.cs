/*
 * Dylan Rothbauer
 * 02/21/24
 * 
 * Handles scene transtions on door
 * 
 * CHANGE LOG
 * Dylan - 02/21/24 - Added this new script for door functionality instead of player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToGoTo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToGoTo);
        }
    }
}
