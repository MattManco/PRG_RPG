using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager Instance { get; private set; }
    private Dictionary<string, BattleCharacter> characters;
    private Dictionary<string, bool> equipment;
    private Dictionary<string, int> items;


    void Start()
    {
        if (Instance == null)
        {
            Instance = this;

            Load();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Load()
    {
        characters = new Dictionary<string, BattleCharacter>();      
        characters.Add("Warrior", new Warrior());
        characters.Add("Mage", new Mage());

        equipment = new Dictionary<string, bool>();
        items = new Dictionary<string, int>();
    }
}
