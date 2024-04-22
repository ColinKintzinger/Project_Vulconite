using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathscene : MonoBehaviour
{
    public string SceneToLoad = "Start Screen";
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Singleton.Instance.ResetWeapon();
<<<<<<< HEAD
=======
            SceneManager.LoadScene(SceneToLoad);
>>>>>>> parent of a0a29e3 (Fuck it scene chaos. GL Everyone!!)
        }
    }

}
