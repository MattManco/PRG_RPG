// This script defines a ScriptableObject for creating and managing battle entities.
// ScriptableObjects allow you to create reusable configurations for characters or enemies in the Unity Editor.

using System.Collections.Generic;
using UnityEngine;

// Create a menu option in Unity to create new BattleEntityData assets.
[CreateAssetMenu(fileName = "NewBattleEntity", menuName = "Battle/BattleEntity")]
public class BattleEntityData : ScriptableObject
{
    public GameObject spawnablePrefab;

    public BattleEntityType type;

    // The name of the entity (e.g., character or enemy).
    public string entityName;

    // The maximum health of the entity.
    public int baseMaxHealth;

    // The attack power of the entity.
    public int baseAttack;

    // The defense value of the entity, which reduces incoming damage.
    public int baseDefense;

    // A list of abilities the entity can use in battle.
    public List<AbilityData> abilities;
}

public struct BattleEntity
{
    BattleEntityType type;

    // Constructor to initialize the BattleEntity with its data and instance.
    public BattleEntity(BattleEntityType type)
    {
        this.type = type;
    }
}
public enum BattleEntityType
{
    None,
    Player,
    Enemy,
}
