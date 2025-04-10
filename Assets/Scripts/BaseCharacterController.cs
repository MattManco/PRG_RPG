using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class BaseCharacterController : MonoBehaviour
{
    public void Movement(CallbackContext ctx)
    {
        Debug.Log($"Context: {ctx.ReadValue<Vector2>()}");
    }
}
