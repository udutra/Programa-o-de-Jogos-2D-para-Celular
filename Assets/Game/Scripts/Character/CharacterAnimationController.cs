using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

public class CharacterAnimationController : MonoBehaviour {

    private Animator animator;
    private CharacterMovement2D playerMovement;
    private EnemyAIController enemyAIController;
    private PlayerController playerController;

    private void Awake() {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<CharacterMovement2D>();
        enemyAIController = GetComponent<EnemyAIController>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update() {
        animator.SetFloat(CharacterMovementAnimationKeys.HorizontalSpeed, playerMovement.CurrentVelocity.x / playerMovement.MaxGroundSpeed);

        if(playerController != null) {
            animator.SetBool(CharacterMovementAnimationKeys.IsCrouching, playerMovement.IsCrouching);
            animator.SetFloat(CharacterMovementAnimationKeys.VerticalSpeed, playerMovement.CurrentVelocity.y / playerMovement.JumpSpeed);
            animator.SetBool(CharacterMovementAnimationKeys.IsGrounded, playerMovement.IsGrounded);
        }

        if(enemyAIController != null) {
            animator.SetBool(CharacterMovementAnimationKeys.IsChasing, enemyAIController.isChasing);
        }
    }
}