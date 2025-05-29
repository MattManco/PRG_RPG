using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
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


