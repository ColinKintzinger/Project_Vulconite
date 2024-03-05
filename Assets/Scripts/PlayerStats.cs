using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public float health = 100f;
    // Charms


    public void takeDamage(float damage)
    {
        health -= damage;
    }
}