using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

public class CharacterAnimationController : MonoBehaviour {

    private Animator animator;
    private CharacterMovement2D playerMovement;

    private void Awake() {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<CharacterMovement2D>();
    }

    private void Update() {
        animator.SetBool(CharacterMovementAnimationKeys.IsCrouching, playerMovement.IsCrouching);
        animator.SetFloat(CharacterMovementAnimationKeys.HorizontalSpeed, playerMovement.CurrentVelocity.x / playerMovement.MaxGroundSpeed);
        animator.SetFloat(CharacterMovementAnimationKeys.VerticalSpeed, playerMovement.CurrentVelocity.y / playerMovement.JumpSpeed);
        animator.SetBool(CharacterMovementAnimationKeys.IsGrounded, playerMovement.IsGrounded);
    }
}