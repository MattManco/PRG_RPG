using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager Instance { get; private set; }
    public List<BattleEntityData> characterData;
    public Dictionary<string, int> characterExp;
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
        characterExp = new Dictionary<string, int>();

        foreach (var item in characterData)
        {
            characterExp.Add(item.name, 0);
        }

        equipment = new Dictionary<string, bool>();
        items = new Dictionary<string, int>();
    }
}
