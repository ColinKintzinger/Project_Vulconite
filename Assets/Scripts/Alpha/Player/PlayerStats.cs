using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    private const float MAX_HEALTH = 100.0f;
    private const float MAX_SPEED = 10.0f;

    public float health = 100.0f;
    public float speed = 5.0f;
    public float damage = 30.0f;

    public List<Charm> collectedCharms = new List<Charm>(); // List to store collected charms
    public GameObject weapon;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0.0f)
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
        health = 100.0f;
        speed = 4.0f;
        damage = 30.0f;
        collectedCharms.Clear();
    }

    public void EquipWeapon(GameObject weaponObject)
    {
        weapon = weaponObject;
    }

}