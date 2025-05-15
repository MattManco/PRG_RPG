using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    [Header("BattleSpawns - Character")]
    [SerializeField] private Transform battleCharacterSpawnPoint;

    [Header("BattleSpawns - Enemies")]
    [SerializeField] private Transform battleEnemiesSpawnPoint;

    private List<GameObject> spawnedObjects;


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
        spawnedObjects = new List<GameObject>();
    }


    #region BattleSpawns
    ///// <summary>
    ///// Spawns the Battle Character prefab of the playable battle character.
    ///// </summary>
    ///// <param name="identifier">The Type of the inherited BattleCharacter</param>
    public BattleCharacter SpawnBattleEntity(BattleEntityData identifier)
    {
        var spawnPoint = battleEnemiesSpawnPoint;

        if (identifier.type == BattleEntityType.Player)
            spawnPoint = battleCharacterSpawnPoint;

        var go = Instantiate(identifier.spawnablePrefab, spawnPoint);
        var bc = go.GetComponent<BattleCharacter>();
        bc.PlayerName = identifier.entityName;
        spawnedObjects.Add(go);
        return bc;
    }

    public void Unload()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            Destroy(spawnedObjects[i]);
        }
        spawnedObjects.Clear();
    }

    #endregion
}
