using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    public event EventHandler OnInteractAction;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(InputAction.CallbackContext context)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        var inputVector = new Vector2(0f, 0f);
        
        inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        //Normaliza o vetor para que o movimento na diagonal não seja mais rápido que o movimento na horizontal ou vertical
        inputVector = inputVector.normalized;

        return inputVector;
    }
}
