using UnityEngine;

[RequireComponent(typeof(IDamageable))]
[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : CharacterAnimationController {

    private PlayerController player;

    protected override void Awake() {
        base.Awake();
        player = GetComponent<PlayerController>();
        
    }

    protected override void Update() {
        base.Update();
        animator.SetBool(CharacterAnimationKeys.IsCrouching, characterMovement.IsCrouching);
        animator.SetFloat(CharacterAnimationKeys.VerticalSpeed, characterMovement.CurrentVelocity.y / characterMovement.JumpSpeed);
        animator.SetBool(CharacterAnimationKeys.IsGrounded, characterMovement.IsGrounded);
        animator.SetBool(CharacterAnimationKeys.IsAttack, player.Weapon.IsAttacking);
    }
}