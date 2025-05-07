using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    [SerializeField] private Transform battleCharacterSpawnPoint;
    [SerializeField] private GameObject spawnableBattleCharacters;

    // Start is called before the first frame update
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

    public void SpawnObject()
    {
        Instantiate(spawnableBattleCharacters, battleCharacterSpawnPoint);
    }
}
