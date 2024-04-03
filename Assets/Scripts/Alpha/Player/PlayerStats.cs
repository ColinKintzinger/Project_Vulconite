using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int health = 10;
    public int maxHealth;
    public float speed;
    public float maxSpeed;
    public int damage = 1;
    

    public List<Charm> collectedCharms = new List<Charm>(); // List to store collected charms
    public Weapon attackWeapon;

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void EquipCharm(Charm charm)
    {

        collectedCharms.Add(charm);
        Debug.Log("CHARM COLLECTED!");
        charm.ApplyBuff(this);
    }
    
    
}