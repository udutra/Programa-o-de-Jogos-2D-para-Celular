using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(CharacterFacing2D))]
public class EnemyAIController : MonoBehaviour {

    private CharacterMovement2D enemyMovement;
    private CharacterFacing2D enemyFacing2D;
    public Vector2 movementInput;

    private void Start() {
        enemyMovement = GetComponent<CharacterMovement2D>();
        enemyFacing2D = GetComponent<CharacterFacing2D>();
    }

    private void Update() {
        enemyMovement.ProcessMovementInput(movementInput);
        enemyFacing2D.UpdateFacing(movementInput);
    }
}