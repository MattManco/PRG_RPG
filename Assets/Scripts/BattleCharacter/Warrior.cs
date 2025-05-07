using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : BattleCharacter
{
    public override void LoadPlayerPrefab() { }
    public override void Attack(BattleCharacter target) { }
    public override void Defend(BattleCharacter target) { }
    public override void UseAbility(BattleCharacter target, string abilityName) { }
    public override void UseItem(string itemName) { }
    public override void GetDamage(int damage) { }
    public override void Heal(int healAmount) { }
    public override bool LevelUp() 
    {
        var leveled = base.LevelUp();

        if (leveled) { this.Level++; }

        return leveled;
    }
}
