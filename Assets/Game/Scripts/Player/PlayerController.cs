using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterFacing2D))]
[RequireComponent(typeof(IDamageable))]
public class PlayerController : MonoBehaviour {
    private CharacterMovement2D playerMovement;
    private PlayerInput playerInput;
    private CharacterFacing2D playerFacing;
    private IDamageable damageable;
    public IWeapon Weapon { get; private set;}
    [SerializeField] private GameObject weaponObject;
    
    [Header("Camera")]
    [SerializeField] private Transform cameraTarget;
    [Range(0f, 5.0f)]
    [SerializeField] private float cameraTargetOffsetX;
    [Range(0.5f, 50.0f)]
    [SerializeField] private float cameraTargetflipSpeed;
    [Range(0f, 5.0f)]
    [SerializeField] private float characterSpeedInfluence;

    private void Start() {
        playerMovement = GetComponent<CharacterMovement2D>();
        playerInput = GetComponent<PlayerInput>();
        playerFacing = GetComponent<CharacterFacing2D>();
        damageable = GetComponent<IDamageable>();
        damageable.DeathEvent += OnDeath;

        if(weaponObject != null) {
            Weapon = weaponObject.GetComponent<IWeapon>();
        }
    }

    private void Update() {

        //Movimentacao
        Vector2 movimentInput = playerInput.GetMovementInput();
        playerMovement.ProcessMovementInput(movimentInput);

        playerFacing.UpdateFacing(movimentInput);

        //Pulo
        if(playerInput.IsJumpButtonDown()) {
            playerMovement.Jump();
        }

        if(playerInput.IsJumpButtonHeld() == false) {
            playerMovement.UpdateJumpAbort();
        }

        //Agachar
        if(playerInput.IsCrouchButtonDown()) {
            playerMovement.Crouch();
        }

        //Levantar
        else if(playerInput.IsCrouchButtonUp()) {
            playerMovement.UnCrouch();
        }

        //Ataque melee
        if(Weapon != null && playerInput.IsAttackButtonDown()) {
            Weapon.Attack();
        }
    }

    private void FixedUpdate() {
        //Ajuste da camera
        bool isFacingRight = playerFacing.IsFacingRight();
        float targetOffsetX = isFacingRight ? cameraTargetOffsetX : -cameraTargetOffsetX;
        float currentOffsetX = Mathf.Lerp(cameraTarget.localPosition.x, targetOffsetX, Time.fixedDeltaTime * cameraTargetflipSpeed);

        currentOffsetX += playerMovement.CurrentVelocity.x * Time.fixedDeltaTime * characterSpeedInfluence;

        cameraTarget.localPosition = new Vector3(currentOffsetX, cameraTarget.localPosition.y, cameraTarget.localPosition.z);
    }

    private void OnDestroy() {
        if(damageable != null) {
            damageable.DeathEvent -= OnDeath;
        }
    }

    private void OnDeath() {
        //Morrer assim que a gente tomar qualquer dano
        playerMovement.StopImmediately();
        enabled = false;
        //Debug.Log("Tomei Dano");
    }
}
