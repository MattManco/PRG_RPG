using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

//BaseCharacter is the base of a character
public class BaseCharacterController : MonoBehaviour
{
    private Vector2 movementInput;
    [SerializeField] private float movementSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    //This is now a FIXEDupdate
    private void FixedUpdate()
    {
        //transform.position += new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * movementSpeed;

        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * movementSpeed);

        //rb.velocity = new Vector3(movementInput.x, movementInput.y, 0) * movementSpeed;

        //rb.AddForce(new Vector3(movementInput.x, movementInput.y, 0) * movementSpeed);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collison detetected with " + collision.gameObject.name);
    }
}
