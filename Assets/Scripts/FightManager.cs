using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager Instance { get; private set; }
    [Range(0,100),SerializeField] private int chanceToEncounter;


    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public bool CheckForEncounter()
    {
        if (Random.Range(0, 100) < chanceToEncounter)
        {
            Debug.Log("Start Encounter");
            return true;
        }
        return false;
    }
}
