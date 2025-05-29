using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleCharacter: MonoBehaviour
{
    [HideInInspector] public string PlayerName;
    public int ExperiencePoints { get; private set; }
    public int Level { get; private set; }
    [Header("Functionality")]
    public Button selectionButton;
    
    public Health health { get; private set; }
    public int attack;
    public int defense;
    public int fleeChance;

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

    private List<AbilityData> possibleAbillities;
    private AbilityData currentSelectedAbillity;

    #region Set-Up
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
    #endregion


    #region FightLogic


    public void OnAttackButtonClicked()
    {
        AbilityData attack = new AbilityData()
        {
            abilityName = "Basic Attack",
            target = AbilityTargetType.SingleTarget,
            type = AbilityType.action,
            stat = AbilityStatType.attack,
            abilityTime = 0,
        };
        currentSelectedAbillity = attack;
    }    
    
    public void OnSkillButtonClicked()
    {
        FightManager.Instance.SpawnSkillButtons(possibleAbillities);
    }    
    
    public void OnItemButtonClicked()
    {
        FightManager.Instance.SpawnUsableItems();
    }    
    
    public void OnFleeButtonClicked()
    {
        AbilityData fleeAbility = new AbilityData()
        {
            abilityName = "Flee",
            target = AbilityTargetType.SingleTarget,
            type = AbilityType.action,
            stat = AbilityStatType.flee,
            abilityTime = 0,
        };
        currentSelectedAbillity = fleeAbility;
    }
    #endregion
}
