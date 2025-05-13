using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    [Header("BattleSpawns - Character")]
    [SerializeField] private Transform battleCharacterSpawnPoint;
    [SerializeField] private List<GameObject> spawnableBattleCharacters;

    [Header("BattleSpawns - Enemies")]
    [SerializeField] private Transform battleEnemiesSpawnPoint;
    [SerializeField] private List<GameObject> spawnableBattleEnemies;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    #region BattleSpawns
    ///// <summary>
    ///// Spawns the Battle Character prefab of the playable battle character.
    ///// </summary>
    ///// <param name="identifier">The Type of the inherited BattleCharacter</param>
    //public void SpawnBattleCharacter(BattleCharacter identifier, string name)
    //{
    //    //Go through the list of spawnable battle characters
    //    foreach (var character in spawnableBattleCharacters)
    //    {
    //        //Get the Type of the current "selected" BattleCharacter prefab
    //        var battleCharacter = character.GetComponent<BattleCharacter>();

    //        //Check if the type of current (battkeCharacter) and the given (identifier) are the same
    //        if (identifier.GetType() == battleCharacter.GetType())
    //        {
    //            var go = Instantiate(character, battleCharacterSpawnPoint);
    //            go.GetComponent<BattleCharacter>().PlayerName = name;
    //        }
    //    } 
    //}

    ///// <summary>
    ///// Spawns the Battle Enemy prefab.
    ///// </summary>
    ///// <param name="identifier">The Type of the inherited BattleEnemy</param>
    //public void SpawnBattleEnemy(BattleEnemy identifier)
    //{
    //    //Go through the list of spawnable battle enemies
    //    foreach (var enemy in spawnableBattleEnemies)
    //    {
    //        //Get the Type of the current "selected" BattleEnemy prefab
    //        var battleEnemy = enemy.GetComponent<BattleEnemy>();

    //        //Check if the type of current (battleEnemy) and the given (identifier) are the same
    //        if (identifier.GetType() == battleEnemy.GetType())
    //        {
    //            Instantiate(enemy, battleCharacterSpawnPoint);       
    //        }
    //    }
    //}
    #endregion
}
