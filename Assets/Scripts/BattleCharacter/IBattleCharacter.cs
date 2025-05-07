using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter: MonoBehaviour
{
    private int ExperiencePoints;
    public int Level;
    private int Health;
    private int MaxHealth;
    //private Dictionary<string, Abbility> Abilities;
    private GameObject playerPrefab;

    public virtual void LoadPlayerPrefab() { }
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
