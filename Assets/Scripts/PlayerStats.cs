using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float health = 100f;
    // Charms


    public void takeDamage(float damage)
    {
        health -= damage;
    }
}