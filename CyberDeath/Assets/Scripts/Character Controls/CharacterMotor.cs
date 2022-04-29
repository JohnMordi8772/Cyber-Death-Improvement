/*****************************************************************************
// File Name :         CharacterMotor.cs
// Author :            Kyle Grenier
// Creation Date :     09/24/2021
//
// Brief Description : Script responsible for applying movement to characters.
*****************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using GoofyGhosts;

/// <summary>
/// Script responsible for applying movement to characters.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class CharacterMotor : MonoBehaviour
{
    [Tooltip("The character's motor data.")]
    [SerializeField] private CharacterMotorDataSO motorData;

    /// <summary>
    /// Reference to the Animator component.
    /// </summary>
    private Animator animator;

    public UnityAction<int> OnJumpCountChange;
    public UnityAction OnGrounded;
    public UnityAction OnUnGrounded;

    /// <summary>
    /// True if the character is on the ground.
    /// </summary>
    public bool IsGrounded
    {
        get
        {
            return characterController.isGrounded;
        }
    }

    /// <summary>
    /// Reference to the CharacterController component.
    /// </summary>
    private CharacterController characterController;

    /// <summary>
    /// The direction the character wants to move in.
    /// </summary>
    private Vector3 movementDirection;

    /// <summary>
    /// True if the character wants to jump.
    /// i.e. player is pressing Space.
    /// </summary>
    private bool jumped;
    /// <summary>
    /// The number of times the character has jumped
    /// since touching the ground.
    /// </summary>
    private int currentJumps;
    /// <summary>
    /// True of the character jumps from the ground.
    /// Will remain true until the character becomes grounded again.
    /// </summary>
    private bool jumpedFromGround;

    /// <summary>
    /// Multiplier that affects jump height.
    /// </summary>
    private float heightMultiplier;

    /// <summary>
    /// True if the current jump count should be subtracted
    /// when the character jumps.
    /// </summary>
    private bool takeJumpAway;

    /// <summary>
    /// True if the character was previously grounded.
    /// </summary>
    private bool wasGrounded;

    public bool bowFiring;

    /// <summary>
    /// Getting components.
    /// </summary>
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        currentJumps = 0;
        heightMultiplier = 1;
        takeJumpAway = true;
        wasGrounded = true;
        bowFiring = false;
    }

    private void Start()
    {
        motorData.SetBaseValues();
    }

    /// <summary>
    /// Moves the character given an input vector direction.
    /// </summary>
    /// <param name="inputVector">The direction in local space to move the character.</param>
    public void MoveCharacter(Vector3 inputVector)
    {
        Vector3 vel;

        // Calculating the velocity to apply to the character.
        if (!bowFiring)
            vel = inputVector * motorData.movementSpeed.GetStat();
        else
            vel = inputVector * motorData.movementSpeed.GetStat() / 3;

        // Transforming the velocity from local space to world space.
        //vel = transform.TransformDirection(vel);

        if (characterController.isGrounded)
        {
            // If we're grounded, set our desired movement direction
            // to our velocity.
            movementDirection = vel;

            // If we're on the ground, set our Y-axis movement direction 
            // to 0 so we're not building momentum each frame.
            movementDirection.y = 0;

            // Set our current jumps to 0 if they are not already.
            if (currentJumps > 0)
            {
                currentJumps = 0;
                jumpedFromGround = false;
            }

            if (!wasGrounded)
            {
                wasGrounded = true;
                OnGrounded?.Invoke();
            }
        }

        // Jump if the player wants to jump.
        if (GetJumped())
        {
            Jump();
        }

        // If we're not grounded...       
        if (!characterController.isGrounded)
        {
            // Take a jump away from the player if they walk
            // off an edge. This prevents the player from
            // double jumping if they walk off an edge and try to jump.
            if (!jumpedFromGround && currentJumps == 0)
            {
                ++currentJumps;
            }

            // Set movement direction to 0 
            // to remove any momentum we may have had
            // before gravity change.
            if (motorData.gravity == 0)
            {
                movementDirection.y = 0;
            }

            // Slowly bring our movement towards the user's desired input,
            // but preserve our current y-direction so that the arc of the jump is preserved.
            vel.y = movementDirection.y;

            movementDirection = Vector3.Lerp(movementDirection, vel, motorData.airControl * Time.deltaTime);

            // If we were previously grounded, 
            // update wasGrounded to false and invoke the OnUnGrounded event.
            if (wasGrounded)
            {
                wasGrounded = false;
                OnUnGrounded?.Invoke();
            }
        }

        // Subtracting gravity from the movement direction; taking gravity into account.
        movementDirection.y -= motorData.gravity * Time.deltaTime;

        if (motorData.gravity < 0)
            movementDirection.y = -motorData.gravity;


        // Apply the movement to the character.
        characterController.Move(movementDirection * Time.deltaTime);

        // Set animator speed float.
        if (animator != null)
        {
            float absSpeed = Mathf.Abs(movementDirection.x) + Mathf.Abs(movementDirection.z);
            animator.SetFloat("MovementSpeed", absSpeed);

            Vector3 dir = movementDirection.normalized;
            dir.y = 0;

            if (VectorsApproximate(dir, transform.forward, 0.5f))
            {
                animator.SetBool("Forward", true);
                animator.SetBool("Backward", false);
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
            }
            else if (VectorsApproximate(dir, -transform.forward, 0.5f))
            {
                animator.SetBool("Forward", false);
                animator.SetBool("Backward", true);
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
            }
            else if (VectorsApproximate(dir, transform.right, 0.5f) || 
                VectorsApproximate(dir, (transform.right + transform.forward).normalized, 0.5f) ||
                VectorsApproximate(dir, (transform.right - transform.forward).normalized, 0.5f))
            {
                animator.SetBool("Forward", false);
                animator.SetBool("Backward", false);
                animator.SetBool("Right", true);
                animator.SetBool("Left", false);
            }
            else if (VectorsApproximate(dir, -transform.right, 0.5f) ||
                VectorsApproximate(dir, (-transform.right + transform.forward).normalized, 0.5f) ||
                VectorsApproximate(dir, (-transform.right - transform.forward).normalized, 0.5f))
            {
                animator.SetBool("Forward", false);
                animator.SetBool("Backward", false);
                animator.SetBool("Right", false);
                animator.SetBool("Left", true);
            }
            else
            {
                animator.SetBool("Forward", false);
                animator.SetBool("Backward", false);
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
            }

            //animator.SetLayerWeight(1, absSpeed);
        }
    }

    private bool VectorsApproximate(Vector3 one, Vector3 two, float sensitivity)
    {
        return Vector3.Distance(one, two) < sensitivity;
    }

    /// <summary>
    /// Adds an impact force to the character
    /// in the direction they are facing.
    /// </summary>
    /// <param name="force">The force to apply.</param>
    /// <param name="duration">The duration over which the force should be applied.</param>
    public void AddImpact(float force, float duration)
    {
        // Apply the force in the direction the character is moving if they
        // are moving. Else, apply it in the direction they are facing.
        Vector3 forward = (HasXZMovement() ?
            movementDirection.normalized : transform.forward);

        // Don't dash in the up/down direcion
        forward.y = 0;

        Vector3 impact = forward * force;
        MoveCharacter(impact);
        StartCoroutine(LerpImpact(impact, duration));
    }

    /// <summary>
    /// Adds an impact force to the character
    /// in the provided direction.
    /// </summary>
    /// <param name="force">The force to apply.</param>
    /// <param name="duration">The duration over which the force should be applied.</param>
    public void AddImpact(Vector3 force, float duration)
    {
        if (force.y != 0)
        {
            SetJumped(true, 1, false);
        }

        force.y = 0;

        MoveCharacter(force);
        StartCoroutine(LerpImpact(force, duration));
    }

    IEnumerator LerpImpact(Vector3 impact, float duration)
    {
        float currentTime = 0f;

        while (currentTime < duration)
        {
            currentTime += Time.fixedDeltaTime;
            MoveCharacter(Vector3.Lerp(impact, Vector3.zero, currentTime / duration));
            yield return null;
        }
    }

    /// <summary>
    /// Returns true if the character is moving 
    /// on the X-Z plane.
    /// </summary>
    /// <returns>True if the character is moving 
    /// on the X-Z plane.</returns>
    private bool HasXZMovement()
    {
        return movementDirection.x != 0 || movementDirection.z != 0;
    }

    /// <summary>
    /// Rotates the character in a direction.
    /// </summary>
    /// <param name="dir">The direction to rotate the character in.</param>
    public void Rotate(Vector3 dir)
    {
        Quaternion rot;

        if (dir.x == 0 && dir.z == 0)
        {
            rot = Quaternion.LookRotation(transform.forward, Vector3.up);
        }
        else
        {
            Vector3 normalizedDir = dir.normalized;
            normalizedDir.y = 0;

            rot = Quaternion.LookRotation(normalizedDir, Vector3.up);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * motorData.rotateSpeed);
    }

    /// <summary>
    /// Returns true if the character is trying to perform a jump.
    /// </summary>
    /// <returns>True if the character is trying to perform a jump.</returns>
    public bool GetJumped()
    {
        return jumped;
    }

    /// <summary>
    /// Performs the jump action.
    /// </summary>
    private void Jump()
    {
        // If the player jumps, calculate the amount of 
        // upward speed we need to get the player to reach the desired jump height.

        if (currentJumps < motorData.MaxJumps)
        {
            if (characterController.isGrounded)
            {
                jumpedFromGround = true;
            }

            movementDirection.y = Mathf.Sqrt(2 * motorData.gravity * motorData.jumpHeight * heightMultiplier);

            if (takeJumpAway)
                ++currentJumps;

            heightMultiplier = 1; // Reset height multiplier after jumping in case it was changed.
            takeJumpAway = true; // Reset takeJumpAway after jumping in case it was changed from default.

            OnJumpCountChange?.Invoke(currentJumps);
        }

        jumped = false;
    }

    /// <summary>
    /// Set to true if the character is trying to perform a jump.
    /// </summary>
    /// <param name="jumped">True if the character is trying to perform a jump.</param>
    public void SetJumped(bool jumped, float heightMultiplier = 1, bool takeJumpAway = true)
    {
        this.jumped = jumped;
        this.heightMultiplier = heightMultiplier;
        this.takeJumpAway = takeJumpAway;
    }

    /// <summary>
    /// Swaps out the current motor data with the
    /// data provided.
    /// </summary>
    /// <param name="data">The motor data to swap to.</param>
    public void SwapMotorData(CharacterMotorDataSO data)
    {
        motorData = data;
    }

    public void BowFiring()
    {
        bowFiring = true;
    }

    public void BowFinished()
    {
        bowFiring = false;
    }
}