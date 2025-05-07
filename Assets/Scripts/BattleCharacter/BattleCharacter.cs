using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter
{
    public int ExperiencePoints;
    public int Level;
    public int Health;
    public int MaxHealth;
    public bool isCharacterDeath;
    //private Dictionary<string, Abbility> Abilities;

    public virtual void LoadPlayerPrefab(string playerName) 
    {
        SpawnManager.instance.SpawnObject();
    }
    public virtual void Attack(BattleCharacter target) { }
    public virtual void Defend(BattleCharacter target) { }
    public virtual void UseAbility(BattleCharacter target, string abilityName) { }
    public virtual void UseItem(string itemName) { }
    public virtual void GetDamage(int damage) { }
    public virtual void Heal(int healAmount) { }
    public virtual bool LevelUp() {
        if(ExperiencePoints > 100 * Level)
        {
            ExperiencePoints -= 100 * Level; 
            Level++;
            return true;
        }
        return false;
    }
}
