using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.InputSystem.InputAction;

//BaseCharacter is the base of a character
public class BaseCharacterController : MonoBehaviour
{
    private Vector2 movementInput;
    [SerializeField] private float movementSpeed;
    [Range(0,1)][SerializeField] private float slowedFactor;
    private bool isSlowed;
    private bool isPlayerPaused;
    private Vector3Int currentPosition;
    private Vector3Int lastEncounterPosition;

    /// <summary>
    /// returns the first found Tilemap in the scene (!!make sure all Tilemaps have the same Transform!!)
    /// </summary>
    public Tilemap tilemap
    {
        get
        {
            if (m_tilemap == null) m_tilemap = FindObjectOfType<Tilemap>();
            return m_tilemap;
        }
    }
    private Tilemap m_tilemap;

    private void Start()
    {
        //Setting first values
        isSlowed = false;
        isPlayerPaused = false;
    }

    /// <summary>
    /// Movement is called by the input system when the player moves the joystick or presses the arrow keys
    /// </summary>
    /// <param name="ctx">Context provided by Unity Input</param>
    public void Movement(CallbackContext ctx)
    {
        //movementInput is set by unity events
        movementInput = ctx.ReadValue<Vector2>(); //comment
    }


    private void FixedUpdate()
    {
        //If isPlayerPaused is true, the player cannot move, FixedUpdate is "returning" void in the next line
        if (isPlayerPaused) return;

        //Default movement Speed
        var actualMovementSpeed = movementSpeed;
        if(isSlowed) actualMovementSpeed *= slowedFactor; //Multiply by slowedFactor if the player is in a swamp

        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * actualMovementSpeed); // transform + input * deltaTime;
        currentPosition = tilemap.WorldToCell(transform.position); //translates World position to tilemap-cell position
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
        {
            isSlowed = true;
        }
        else if(col.gameObject.CompareTag("FightEncounter"))
        {
            if(currentPosition != lastEncounterPosition)
            {
                lastEncounterPosition = currentPosition;
                // FightManager is a singleton that checks if the player is in an encounter, returning true or false for pausing player
                PausePlayer(FightManager.Instance.CheckForEncounter(this)); 
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
        {
            isSlowed = false;
        }
    }

    public void PausePlayer(bool isPaused)
    {
        isPlayerPaused = isPaused;
    }
}
