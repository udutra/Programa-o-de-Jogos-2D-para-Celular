using UnityEngine;
using Platformer2D.Character;

public class CharacterAnimationController : MonoBehaviour {

    protected Animator animator;
    protected CharacterMovement2D characterMovement;
    protected IDamageable damageable;

    protected virtual void Awake() {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement2D>();
        damageable = GetComponent<IDamageable>();
        if(damageable != null) {
            damageable.DeathEvent += OnDeath;
        }
    }

    protected virtual void Update() {
        animator.SetFloat(CharacterAnimationKeys.HorizontalSpeed, characterMovement.CurrentVelocity.x / characterMovement.MaxGroundSpeed);
    }

    protected void OnDestroy() {
        if(damageable != null) {
            damageable.DeathEvent -= OnDeath;
        }
    }

    protected void OnDeath() {
        animator.SetTrigger(CharacterAnimationKeys.Dead);
    }
}