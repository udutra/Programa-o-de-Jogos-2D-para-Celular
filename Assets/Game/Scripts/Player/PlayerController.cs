using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;


[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour {
    private CharacterMovement2D playerMovement;
    private SpriteRenderer spriteRenderer;
    private PlayerInput playerInput;

    public Sprite crouchedSprite, idleSprite;

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
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update() {

        //Movimentacao
        Vector2 movimentInput = playerInput.GetMovementInput();
        playerMovement.ProcessMovementInput(movimentInput);

        if(movimentInput.x > 0) {
            spriteRenderer.flipX = false;
        }
        else if(movimentInput.x < 0) {
            spriteRenderer.flipX = true;
        }

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

            //TODO: Remover quando adicionar animação
            spriteRenderer.sprite = crouchedSprite;
        }

        //Levantar
        else if(playerInput.IsCrouchButtonUp()) {
            playerMovement.UnCrouch();

            //TODO: Remover quando adicionar animação
            spriteRenderer.sprite = idleSprite;
        }
    }

    private void FixedUpdate() {
        //Ajuste da camera
        bool isFacingRight = spriteRenderer.flipX == false;
        float targetOffsetX = isFacingRight ? cameraTargetOffsetX : -cameraTargetOffsetX;
        float currentOffsetX = Mathf.Lerp(cameraTarget.localPosition.x, targetOffsetX, Time.fixedDeltaTime * cameraTargetflipSpeed);

        currentOffsetX += playerMovement.CurrentVelocity.x * Time.fixedDeltaTime * characterSpeedInfluence;

        cameraTarget.localPosition = new Vector3(currentOffsetX, cameraTarget.localPosition.y, cameraTarget.localPosition.z);
    }
}
