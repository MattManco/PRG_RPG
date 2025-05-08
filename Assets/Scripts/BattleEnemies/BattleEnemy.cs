using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy : MonoBehaviour
{
    private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int level;
    [SerializeField] private int ExpDrop;
    [SerializeField] private int goldDrop;

    public virtual void LoadPlayerPrefab(string playerName)
    {
        SpawnManager.instance.SpawnBattleEnemy(this);
    }

    public virtual void Attack(BattleCharacter target)
    {
        // Apply damage to target
        target.TakeDamage(attack);
    }

    public virtual void TakeDamage(int damage)
    {
        //Calculate actual damage after defense
        var actualDamage = Mathf.Max(0, damage - defense);
        // Apply damage to health
        health -= actualDamage;
        // Check if health is less than or equal to zero
        if (health <= 0)
        {
            // Set health a minimum of zero
            health = 0;
            Die();
        }
    }

    public void Die()
    {
        // Handle enemy death
    }
}
