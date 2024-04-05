using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour 
{
    public bool enableMobileInputs = true;
    private PlayerInputActions playerInputAction;

    private void Awake()
    {
        playerInputAction = new PlayerInputActions();
        playerInputAction.Player.Enable();
    }
    public Vector2 GetMovementVectorNomalized()
    {
        Vector2 input = playerInputAction.Player.Move.ReadValue<Vector2>(); ;

        Vector2 inputDir = input.normalized;
        return inputDir;
        
    }

}