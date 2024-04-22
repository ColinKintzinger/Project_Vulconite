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
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Singleton.Instance.ResetWeapon();
=======
        if (Input.GetMouseButtonDown(0))
        {
>>>>>>> Ottos
            SceneManager.LoadScene(SceneToLoad);
        }
    }

}
