/*****************************************************************************
// File Name :         PlayerCharacterController.cs
// Author :            Kyle Grenier
// Creation Date :     09/24/2021
//
// Brief Description : Script responsible for obtaining player input and 
                       applying it to the character motor.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
using GoofyGhosts;

/// <summary>
/// Script responsible for obtaining player input and 
/// applying it to the character motor.
/// </summary>
[RequireComponent(typeof(CharacterMotor))]
public class PlayerCharacterController : MonoBehaviour
{
    /// <summary>
    /// Reference to the attached CharacterMotor component.
    /// </summary>
    private CharacterMotor motor;

    /// <summary>
    /// The object to subscribe events to.
    /// </summary>
    private PlayerControls controls;
    /// <summary>
    /// The InputAction associated with moving the character.
    /// </summary>
    private InputAction movementInputAction;
    /// <summary>
    /// The InputAction associated with rotating the character.
    /// </summary>
    private InputAction rotationInputAction;

    /// <summary>
    /// A vector that holds the player's input.
    /// </summary>
    private Vector3 inputVector;
    /// <summary>
    /// A vector that holds the player's rotation.
    /// </summary>
    private Vector3 rotationVector;

    [SerializeField] private BoolChannelSO controlsDisableChannel;

    MouseLookNew mouseScript;

    #region -- // Initialization // --
    /// <summary>
    /// Creating the controls object and getting components.
    /// </summary>
    private void Awake()
    {
        controls = new PlayerControls();
        motor = GetComponent<CharacterMotor>();
        mouseScript = GetComponent<MouseLookNew>();
    }

    /// <summary>
    /// Event subscribing.
    /// </summary>
    private void OnEnable()
    {
        movementInputAction = controls.Player.Movement;
        rotationInputAction = controls.Player.Rotate;
        controls.Player.Jump.started += _ => motor.SetJumped(true);
        controls.Player.Jump.canceled += _ => motor.SetJumped(false);

        controlsDisableChannel.OnEventRaised += ToggleControls;


        movementInputAction.Enable();
        rotationInputAction.Enable();
        controls.Player.Jump.Enable();
    }

    /// <summary>
    /// Disabling input events.
    /// </summary>
    private void OnDisable()
    {
        controlsDisableChannel.OnEventRaised -= ToggleControls;

        movementInputAction.Disable();
        rotationInputAction.Disable();
        controls.Player.Jump.Disable();
    }
    #endregion

    /// <summary>
    /// Obtain input every frame.
    /// </summary>
    private void Update()
    {
        Vector2 input = movementInputAction.ReadValue<Vector2>();
        Vector2 rotation = rotationInputAction.ReadValue<Vector2>();

        inputVector = new Vector3(input.x, 0, input.y);
        rotationVector = new Vector3(rotation.x, 0, rotation.y);
        motor.MoveCharacter(inputVector);
        motor.Rotate(rotationVector);

        if(Gamepad.current != null || !MouseLookNew.scriptEnabled)
        {
            mouseScript.enabled = false;
        }
        else
        {
            mouseScript.enabled = true;
        }
    }

    private void ToggleControls(bool toggle)
    {
        if (toggle)
        {
            movementInputAction.Enable();
            rotationInputAction.Enable();
            controls.Player.Jump.Enable();
        }
        else
        {
            movementInputAction.Disable();
            rotationInputAction.Disable();
            controls.Player.Jump.Disable();
        }
    }
}