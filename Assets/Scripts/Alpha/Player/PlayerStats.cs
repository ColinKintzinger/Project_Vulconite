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
        // Switch statement to determine stat buffs based on name of charm prefab? --- will follow up soon -- might be able to use inheritance

        collectedCharms.Add(charm);
        Debug.Log("CHARM COLLECTED!");
    }
}