// This script defines a ScriptableObject for creating and managing battle entities.
// ScriptableObjects allow you to create reusable configurations for characters or enemies in the Unity Editor.

using System.Collections.Generic;
using UnityEngine;

// Create a menu option in Unity to create new BattleEntityData assets.
[CreateAssetMenu(fileName = "NewBattleEntity", menuName = "Battle/BattleEntity")]
public class BattleEntityData : ScriptableObject
{
    public GameObject spawnablePrefab;

    // The name of the entity (e.g., character or enemy).
    public string entityName;

    // The level of the entity.
    public int level;

    // The current health of the entity.
    public int health;

    // The maximum health of the entity.
    public int maxHealth;

    // The attack power of the entity.
    public int attack;

    // The defense value of the entity, which reduces incoming damage.
    public int defense;

    // Indicates whether the entity is dead.
    public bool isDead;

    // A list of abilities the entity can use in battle.
    public List<string> abilities;
}
