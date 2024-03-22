using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float health = 100f;
    public List<Charm> collectedCharms = new List<Charm>(); // List to store collected charms


    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void EquipCharm(Charm charm)
    {
        // Switch statement to check charm names and apply buff -- will follow up -- might do inheritance

        collectedCharms.Add(charm);
        Debug.Log("CHARM COLLECTED!");
        charm.ApplyBuff(this);
    }
}