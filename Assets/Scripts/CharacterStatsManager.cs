using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager Instance { get; private set; }
    public Dictionary<string, BattleCharacter> characters { get; private set; }
    public Dictionary<string, bool> equipment { get; private set; }
    public Dictionary<string, int> items { get; private set; }


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
        characters = new Dictionary<string, BattleCharacter>
        {
            { "Xena", new Warrior() },
            { "Mighty Mole", new Mage() },
            { "Peter Pan", new Archer() }
        };      

        equipment = new Dictionary<string, bool>();
        items = new Dictionary<string, int>();
    }
}
