using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : BattleCharacter
{
    public override void Attack(BattleCharacter target) { }
    public override void Defend(BattleCharacter target) { }
    public override void UseAbility(BattleCharacter target, string abilityName) { }
    public override void UseItem(string itemName) { }
    public override void GetDamage(int damage) { }
    public override void Heal(int healAmount) { }
}
