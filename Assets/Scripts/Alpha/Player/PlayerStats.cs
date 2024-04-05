using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int health = 10;
    public int maxHealth;
    public float speed;
    public float maxSpeed;
    public int damage = 1;

    public List<Charm> collectedCharms = new List<Charm>(); // List to store collected charms
    //public Weapon attackWeapon;


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            SceneManager.LoadScene("LoseScene");
            health = 10;
        }
    }

    public void EquipCharm(Charm charm)
    {

        collectedCharms.Add(charm);
        Debug.Log("CHARM COLLECTED!");
        charm.ApplyBuff(this);
    }


}