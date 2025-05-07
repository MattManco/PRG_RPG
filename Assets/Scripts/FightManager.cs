using System.Collections;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager Instance { get; private set; }
    [Range(0,100),SerializeField] private int chanceToEncounter;
    [SerializeField] GameObject fightCanvas;
    private bool isFightActive;


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

        isFightActive = false;
    }

    public bool CheckForEncounter()
    {
        if (Random.Range(0, 100) < chanceToEncounter)
        {
            StartFight();
        }
        return isFightActive;
    }

    private void StartFight()
    {
        fightCanvas.SetActive(true);
        isFightActive = true;
        StartCoroutine(FightCoroutine());
    }

    private IEnumerator FightCoroutine()
    {
        //Load Characters
        LoadCharacter();
        //Load Random Enemies
        //Load BackgroundImages
        //Load Music
        //Load UI
        //Load Items

        /*while(transition){
         * 
         * DoStuff();
         * yield return new WaitForEndOfFrame();
         * 
         * }*/

        while (isFightActive)
        {
            //Check whos turn
            //Make Player/ Enemies Turn
            //Show and wait for end of Fight
            //Set isFightActive to false <- GameOver? Enemies Death?
            yield return new WaitForSeconds(3f);
            isFightActive = false; //Because: Nobody got Time for this
        }

        //End Fight and gain XP and Gold
        //Level UP?
    }
    private void LoadCharacter()
    {

    }
}
