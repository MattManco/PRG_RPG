using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbilityData", menuName = "Battle/Ability")]
public class AbilityData : ScriptableObject
{
    public string abilityName;
    public AbilityTargetType target;
    public AbilityType type;
    public AbilityStatType stat;
    public uint abilityTime;
}

public enum AbilityTargetType
{
    SingleTarget,
    MultiTarget,
}

public enum  AbilityType
{
    incremental,
    decremental,
    action,
}


public enum AbilityStatType
{
    health,
    attack,
    defense,
    revival,
    flee,
}
