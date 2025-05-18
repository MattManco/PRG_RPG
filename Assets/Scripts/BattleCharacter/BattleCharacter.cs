using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleCharacter: MonoBehaviour
{
    [HideInInspector] public string PlayerName;
    public int ExperiencePoints { get; private set; }
    [SerializeField] public int Level { get; private set; }
    public Health health { get; private set; }
    //public int attack { get; private set; }
    //public int defense { get; private set; }
    public bool isCharacterDeath { get; private set; }

    public virtual void SetExp(int experience)
    {
        var experienceToGain = experience;
        Level = 1; // Reset level to 1 before calculating

        while (experienceToGain > 0)
        {
            var requiredToLevelUp = 100 * Level;

            if(requiredToLevelUp < experienceToGain)
            {
                Level++;
                experienceToGain -= requiredToLevelUp;
            }
            else
            {
                ExperiencePoints = experienceToGain;
                experienceToGain = 0;
            }
        }
    }

    public static int GetExperienceRequirement(int level)
    {
        var expReq = 0;

        for (int i = 1; i <= level; i++)
        {
            expReq += 100 * i;
        }

        return expReq;
    }

    [Header("VISUALS")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text maxHpText;


    public virtual void SetHP()
    {
        SetHP(health);
    }

    public virtual void SetHP(Health health)
    {
        this.health = health;
    }

    public void SetVisuals()
    {
        nameText.text = PlayerName + " Level: " + Level;
        maxHpText.text = health.maxHealth.ToString();
        hpText.text = health.health.ToString();
    }


    //public virtual void Attack(BattleEnemy target) { }
    //public virtual void Defend(BattleEnemy target) { }
    //public virtual void UseAbility(BattleEnemy target, string abilityName) { }
    //public virtual void UseItem(string itemName) { }
    //public virtual void Heal(int healAmount) { }
    //public virtual bool LevelUp() {
    //    if(ExperiencePoints > 100 * Level)
    //    {
    //        ExperiencePoints -= 100 * Level; 
    //        Level++;
    //        return true;
    //    }
    //    return false;
    //}

    //public virtual void AddExperiencePoints(int exp)
    //{
    //    ExperiencePoints += exp;
    //    LevelUp();
    //}
}
