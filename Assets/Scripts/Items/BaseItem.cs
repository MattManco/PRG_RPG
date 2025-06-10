using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create a menu option in Unity to create new BattleEntityData assets.
[CreateAssetMenu(fileName = "BaseItem", menuName = "Items/BaseItems")]
public class BaseItem : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;
    [SerializeField] private int itemPrice;
    [SerializeField] private Sprite itemIcon;
    [SerializeField] private bool isConsumable;
    [SerializeField] private bool isEquipped;
    [SerializeField] private bool isUsableInBattle;
    [SerializeField] private bool isUsableOutsideBattle;
    [SerializeField] private bool isStackable;
    [SerializeField] private bool isSellable;
    [SerializeField] private bool isCraftable;
    [SerializeField] private bool isTradable;
    [SerializeField] private bool isDestroyable;
    [SerializeField] private bool isQuestItem;
}


