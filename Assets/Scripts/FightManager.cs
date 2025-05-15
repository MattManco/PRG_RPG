// This script manages the fight system in the game. It handles fight initiation, 
// fight logic, and cleanup after the fight ends.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    // Singleton instance of the FightManager to ensure only one instance exists.
    public static FightManager Instance { get; private set; }

    // The chance (in percentage) for a fight to occur when checked.
    [Range(0, 100), SerializeField] private int chanceToEncounter;

    // Reference to the fight UI canvas that will be displayed during a fight.
    [SerializeField] GameObject fightCanvas;

    // Tracks whether a fight is currently active.
    private bool isFightActive;

    // Reference to the player's character controller.
    private BaseCharacterController characterController;

    [SerializeField] private List<BattleEntityData> battleEnemies;

    private List<BattleCharacter> spawnedEnemies;
    private List<BattleCharacter> spawnedCharacters;

    // Called when the script is initialized. Ensures the Singleton pattern is enforced.
    void Start()
    {
        if (Instance == null)
        {
            // Set this instance as the Singleton instance.
            Instance = this;
        }
        else if (Instance != this)
        {
            // Destroy duplicate instances of the FightManager.
            Destroy(gameObject);
        }

        // Initialize the fight state as inactive.
        isFightActive = false;
        spawnedCharacters = new List<BattleCharacter>();
        spawnedEnemies = new List<BattleCharacter>();
    }

    // Checks if a fight should start based on the encounter chance.
    public bool CheckForEncounter(BaseCharacterController characterController)
    {
        // Store the reference to the player's character controller.
        this.characterController = characterController;

        // Generate a random number and compare it to the chanceToEncounter.
        if (Random.Range(0, 100) < chanceToEncounter)
        {
            // If the random number is less than the chance, start the fight coroutine.
            StartCoroutine(FightCoroutine());
        }

        // Return whether a fight is currently active.
        return isFightActive;
    }

    // Coroutine that handles the fight logic.
    private IEnumerator FightCoroutine()
    {
        // Set the fight state to active.
        isFightActive = true;

        // Enable the fight UI canvas.
        fightCanvas.SetActive(isFightActive);

        // Load the player's characters into the fight.
        LoadCharacter();

        // Load Random Enemies
        SpawnRandomEnemy();
        // Load BackgroundImages
        // Load Music
        // Load UI
        // Load Items

        /* Example of a transition phase:
         * while(transition){
         *     DoStuff();
         *     yield return new WaitForEndOfFrame();
         * }
         */

        // Main fight loop. Runs as long as the fight is active.
        while (isFightActive)
        {
            // Placeholder for fight logic:
            // - Determine whose turn it is.
            // - Execute player/enemy actions.
            // - Check for fight end conditions (e.g., player or enemy defeat).

            // Wait for 3 seconds before the next iteration (placeholder logic).
            yield return new WaitForSeconds(3f);

            // End the fight
            var battleOverType = CheckForEndFight();
            isFightActive = battleOverType == BattleEntityType.None; // Fight ends here for now.
        }

        // After the fight ends:
        // - Grant rewards like XP and gold.
        // - Check for level-ups.
        // - Save progress in the StatsManager.
        // - Clean up all battle-related assets.
        UnloadFightUI();

        // Disable the fight UI canvas.
        fightCanvas.SetActive(isFightActive);

        // Resume player movement or other gameplay mechanics.
        characterController.PausePlayer(isFightActive);
    }

    // Loads the player's characters into the fight.
    private void LoadCharacter()
    {
        // Iterate through all characters in the CharacterStatsManager.
        foreach (var character in CharacterStatsManager.Instance.characterData)
        {
            // Load the character's prefab into the fight scene.
            spawnedCharacters.Add(SpawnManager.instance.SpawnBattleEntity(character));
        }
    }

    private void SpawnRandomEnemy()
    {
        var count = Random.Range(1, 7);

        for (int i = 0; i < count; i++)
        {
            var randomEnemy = battleEnemies[Random.Range(0, battleEnemies.Count)];
            spawnedEnemies.Add(SpawnManager.instance.SpawnBattleEntity(randomEnemy));
        }
    }

    private BattleEntityType CheckForEndFight()
    {
        // Check if all enemies are dead using a lambda expression.
        bool allEnemiesDead = spawnedEnemies.TrueForAll(enemy => enemy.isCharacterDeath);

        // Check if all players are dead using a lambda expression.
        bool allPlayersDead = spawnedCharacters.TrueForAll(character => character.isCharacterDeath);

        // The fight continues as long as not all players or all enemies are dead.
        if(allEnemiesDead)
            return BattleEntityType.Enemy;
        if(allPlayersDead)
            return BattleEntityType.Player;
        return BattleEntityType.None;
    }

    private void UnloadFightUI()
    {
        spawnedCharacters.Clear();
        spawnedEnemies.Clear();
        SpawnManager.instance.Unload();
    }
}
