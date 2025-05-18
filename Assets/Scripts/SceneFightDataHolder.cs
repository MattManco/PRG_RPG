using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFightDataHolder : MonoBehaviour
{
    [SerializeField] private List<Sprite> fightBackgrounds;
    [SerializeField] private List<BattleEntityData> battleEnemies;
    [SerializeField] private List<AudioClip> battleMusic;

    [SerializeField] private Vector2Int enemiesCountRange;
    [SerializeField] private Vector2Int levelCaps;


    public Sprite GetFightBackgroundSprite()
    {
        return fightBackgrounds[Random.Range(0, fightBackgrounds.Count)];
    }

    public AudioClip GetBattleMusic()
    {
        return battleMusic[Random.Range(0, battleMusic.Count)];
    }   

    public List<BattleEntityData> GetBattleEnemies(out List<int> enemyLevels, out List<Health> enemyHP)
    {
        var count = Random.Range(enemiesCountRange.x, enemiesCountRange.y);
        List<BattleEntityData> selectedBattleEnemies = new List<BattleEntityData>();
        List<int> selectedEnemyLevels = new List<int>();
        List<Health> selectedEnemyHP = new List<Health>();


        for (int i = 0; i < count; i++)
        {
            var enemy = battleEnemies[Random.Range(0, battleEnemies.Count)];
            selectedBattleEnemies.Add(enemy);
            var selectedLevel = Random.Range(levelCaps.x, levelCaps.y);
            selectedEnemyLevels.Add(BattleCharacter.GetExperienceRequirement(selectedLevel));
            selectedEnemyHP.Add(
                new Health(enemy.baseMaxHealth * selectedLevel, enemy.baseMaxHealth * selectedLevel));
        }

        enemyLevels = selectedEnemyLevels;
        enemyHP = selectedEnemyHP;
        return selectedBattleEnemies;
    }
}
