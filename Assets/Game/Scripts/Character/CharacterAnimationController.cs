using UnityEngine;
using Platformer2D.Character;

public class CharacterAnimationController : MonoBehaviour {

    protected Animator animator;
    protected CharacterMovement2D characterMovement;

    protected virtual void Awake() {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement2D>();
    }

    protected virtual void Update() {
        animator.SetFloat(CharacterMovementAnimationKeys.HorizontalSpeed, characterMovement.CurrentVelocity.x / characterMovement.MaxGroundSpeed);
    }
}