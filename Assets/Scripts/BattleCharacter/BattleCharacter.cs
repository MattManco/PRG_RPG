using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleCharacter: MonoBehaviour
{
    [SerializeField] public string PlayerName;
    [SerializeField] private int ExperiencePoints;
    [SerializeField] private int Level;
    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private bool isCharacterDeath;
    //private Dictionary<string, Abbility> Abilities;

    [Header("VISUALS")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text maxHpText;

    public virtual void LoadPlayerPrefab(string playerName) 
    {
        //PlayerName = playerName;
        SpawnManager.instance.SpawnBattleCharacter(this, playerName);
    }

    public void Start()
    {
        nameText.text = PlayerName + " Level: " + Level;
        hpText.text = Health.ToString();
        maxHpText.text = MaxHealth.ToString();
    }

    public virtual void Attack(BattleCharacter target) { }
    public virtual void Defend(BattleCharacter target) { }
    public virtual void UseAbility(BattleCharacter target, string abilityName) { }
    public virtual void UseItem(string itemName) { }
    public virtual void TakeDamage(int damage) { }
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
