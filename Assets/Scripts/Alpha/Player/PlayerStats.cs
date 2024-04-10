using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    private const int MAX_HEALTH = 10;
    private const float MAX_SPEED = 2.0f;

    public int health = 10;
    public float speed;
    public int damage = 1;

    public List<Charm> collectedCharms = new List<Charm>(); // List to store collected charms
    public GameObject weapon;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            SceneManager.LoadScene("LoseScene");
            resetPlayerStats();
        }
    }

    public void EquipCharm(Charm charm)
    {

        collectedCharms.Add(charm);
        Debug.Log("CHARM COLLECTED!");
        charm.ApplyBuff(this);
    }

    private void resetPlayerStats()
    {
        health = 10;
        speed = 1.0f;
        damage = 1;
        collectedCharms.Clear();
    }

    public void EquipWeapon(GameObject weaponObject)
    {
        weapon = weaponObject;
    }

}