using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;


[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterFacing2D))]
public class PlayerController : MonoBehaviour {
    private CharacterMovement2D playerMovement;
    private PlayerInput playerInput;
    private CharacterFacing2D playerFacing;

    [Header("Camera")]
    public Transform cameraTarget;
    [Range(0f, 5.0f)]
    public float cameraTargetOffsetX;
    [Range(0.5f, 50.0f)]
    public float  cameraTargetflipSpeed;
    [Range(0f, 5.0f)]
    public float characterSpeedInfluence;

    private void Start() {
        playerMovement = GetComponent<CharacterMovement2D>();
        playerInput = GetComponent<PlayerInput>();
        playerFacing = GetComponent<CharacterFacing2D>();
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
    }

    private void FixedUpdate() {
        //Ajuste da camera
        bool isFacingRight = playerFacing.IsFacingRight();
        float targetOffsetX = isFacingRight ? cameraTargetOffsetX : -cameraTargetOffsetX;
        float currentOffsetX = Mathf.Lerp(cameraTarget.localPosition.x, targetOffsetX, Time.fixedDeltaTime * cameraTargetflipSpeed);

        currentOffsetX += playerMovement.CurrentVelocity.x * Time.fixedDeltaTime * characterSpeedInfluence;

        cameraTarget.localPosition = new Vector3(currentOffsetX, cameraTarget.localPosition.y, cameraTarget.localPosition.z);
    }
}
