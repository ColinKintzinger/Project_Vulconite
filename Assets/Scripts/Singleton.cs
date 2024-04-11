using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance {  get; private set; }
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWeapon(GameObject weaponObject)
    {
        weapon = weaponObject;
        DontDestroyOnLoad(weapon);
        // Destroy other game object that isn't the one I picked up
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
    }

    public GameObject GetWeapon()
    {
        return weapon;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


}
