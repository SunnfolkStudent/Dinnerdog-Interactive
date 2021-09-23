using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public Vector2 moveVector;
    [HideInInspector] public bool jump;
    [HideInInspector] public bool longJump;
    [HideInInspector] public bool downDash;
    
    private void Update()
    {
        moveVector.x = (Keyboard.current.aKey.isPressed ? -1f : 0f) + (Keyboard.current.dKey.isPressed ? 1f : 0f);
        moveVector.y = (Keyboard.current.sKey.isPressed ? -1f : 0f) + (Keyboard.current.wKey.isPressed ? 1f : 0f);

        jump = Keyboard.current.spaceKey.wasPressedThisFrame;
        longJump = Keyboard.current.spaceKey.isPressed;
        
        downDash = Keyboard.current.sKey.wasPressedThisFrame;
    }
}