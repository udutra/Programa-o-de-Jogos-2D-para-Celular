public class PlayerAnimationController : CharacterAnimationController {

    private IDamageable damageable;

    protected override void Awake() {
        base.Awake();
        damageable = GetComponent<IDamageable>();
        if(damageable != null) {
            damageable.DeathEvent += OnDeath;
        }
    }

    protected override void Update() {
        base.Update();
        animator.SetBool(CharacterMovementAnimationKeys.IsCrouching, characterMovement.IsCrouching);
        animator.SetFloat(CharacterMovementAnimationKeys.VerticalSpeed, characterMovement.CurrentVelocity.y / characterMovement.JumpSpeed);
        animator.SetBool(CharacterMovementAnimationKeys.IsGrounded, characterMovement.IsGrounded);
    }

    private void OnDestroy() {
        if(damageable != null) {
            damageable.DeathEvent -= OnDeath;
        }
    }

    private void OnDeath() {
        animator.SetTrigger(CharacterMovementAnimationKeys.Dead);
    }
}