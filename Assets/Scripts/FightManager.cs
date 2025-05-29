// This script manages the fight system in the game. It handles fight initiation, 
// fight logic, and cleanup after the fight ends.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class FightManager : MonoBehaviour
{
    // Singleton instance of the FightManager to ensure only one instance exists.
    public static FightManager Instance { get; private set; }

    // The chance (in percentage) for a fight to occur when checked.
    [Range(0, 100), SerializeField] private int chanceToEncounter;

    // Reference to the fight UI canvas that will be displayed during a fight.
    [SerializeField] GameObject fightCanvas;
    [SerializeField] Image fightBackgroundSprite;
    [SerializeField] AudioSource fightMusic;

    [Header("PlayerUIButtons")]
    [SerializeField] Button attackButton;
    [SerializeField] Button skillButton;
    [SerializeField] Button itemButton;
    [SerializeField] Button fleeButton;

    [Header("UIContainer")]
    [SerializeField] Transform playerContextUI;


    // Tracks whether a fight is currently active.
    private bool isFightActive;

    // Reference to the player's character controller.
    private BaseCharacterController characterController;

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
        var battleState = BattleState.PlayerTransition;

        // Enable the fight UI canvas.
        fightCanvas.SetActive(isFightActive);

        // Load the player's characters into the fight.
        LoadCharacter();

        // Load Random Enemies
        SpawnRandomEnemy();
        // Load BackgroundImages
        LoadBackground();

        // Load Music
        LoadBattleMusic();

        // Load UI
        EnableBattleButtons(false);


        // Main fight loop. Runs as long as the fight is active.
        while (isFightActive)
        {
            switch (battleState)
            {
                case BattleState.PlayerTurn:

                    BattleCharacter nextPlayerCharacter = spawnedCharacters[0];

                    while (battleState == BattleState.PlayerTurn)
                    {
                        yield return new WaitForEndOfFrame();

                        //if(playerActions.Count >= spawnedCharacters.Count)
                        //{
                        //    battleState = BattleState.EnemyTransition;
                        //}
                    }
                    break;
                case BattleState.EnemyTurn:
                    break;
                case BattleState.PlayerTransition:
                    EnableBattleButtons(true);
                    battleState = BattleState.PlayerTurn;
                    break;
                case BattleState.EnemyTransition:
                    EnableBattleButtons(false);
                    battleState = BattleState.EnemyTurn;
                    break;
                default:
                    break;
            }

            // Placeholder for fight logic:
            // - Determine whose turn it is.
            // - Execute player/enemy actions.
            // - Check for fight end conditions (e.g., player or enemy defeat).

            // Wait for 3 seconds before the next iteration (placeholder logic).
            yield return new WaitForEndOfFrame();

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
        foreach (var character in CharacterStatsManager.Instance.characterData)
        {
            // Load the character's prefab into the fight scene.
            spawnedCharacters.Add(SpawnManager.instance.SpawnBattleEntity(character));
        }
    }

    private void SpawnRandomEnemy()
    {
        List<int> enemyLevels = new List<int>();
        List<Health> enemyHealth = new List<Health>();
        var enemies = FindObjectOfType<SceneFightDataHolder>().GetBattleEnemies(out enemyLevels, out enemyHealth);

        for (int i = 0; i < enemies.Count; i++)
        {
            spawnedEnemies.Add(SpawnManager.instance.SpawnBattleEntity(enemies[i], enemyLevels[i], enemyHealth[i]));
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

    private void LoadBackground()
    {
        // Get a random background sprite from the FightBackgroundDataHolder.
        var backgroundSprite = FindObjectOfType<SceneFightDataHolder>().GetFightBackgroundSprite();

        // Set the background image in the fight canvas.
        if (backgroundSprite == null) fightBackgroundSprite.color = new Color(0, 0, 0, 0);
        else 
        { 
            fightBackgroundSprite.color = new Color(.7f, .7f, .7f, 1); //<-- Set the color to gray
            fightBackgroundSprite.sprite = backgroundSprite;
        }
    }

    private void LoadBattleMusic()
    {
        fightMusic.clip = FindObjectOfType<SceneFightDataHolder>().GetBattleMusic();
        fightMusic.Play();
    }


    private void EnableBattleButtons(bool active, BattleCharacter currentCharacter = null)
    {
        // Enable or disable the buttons based on the 'active' parameter.
        attackButton.interactable = active;
        skillButton.interactable = active;
        itemButton.interactable = active;
        fleeButton.interactable = active;

        // If buttons are being enabled, subscribe them to character-specific actions.
        if (active && currentCharacter != null)
        {

            attackButton.onClick.AddListener(() => currentCharacter.OnAttackButtonClicked());

                // Subscribe the skill button to the character's skill action.
            skillButton.onClick.AddListener(() => currentCharacter.OnSkillButtonClicked());

                // Subscribe the item button to the character's item usage action.
            itemButton.onClick.AddListener(() => currentCharacter.OnItemButtonClicked());

            // Subscribe the flee button to a general flee action.
            fleeButton.onClick.AddListener(() => currentCharacter.OnFleeButtonClicked());
        }
        else
        {
            // Unsubscribe all listeners from the buttons to avoid duplicate subscriptions.
            attackButton.onClick.RemoveAllListeners();
            skillButton.onClick.RemoveAllListeners();
            itemButton.onClick.RemoveAllListeners();
            fleeButton.onClick.RemoveAllListeners();
        }
    }

    public void SpawnSkillButtons(List<AbilityData> abilities)
    {
        ///ToDo!
    }

    public void SpawnUsableItems()
    {
        ///ToDo!
    }
}

public enum BattleState 
{
    PlayerTurn,
    EnemyTurn,
    PlayerTransition,
    EnemyTransition,
}