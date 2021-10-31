using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(CharacterFacing2D))]
public class EnemyAIController : MonoBehaviour {

    private CharacterMovement2D enemyMovement;
    private CharacterFacing2D enemyFacing2D;
    private Vector2 movementInput;
    private bool isChasing;

    public bool IsChasing {
        get => isChasing;
        set => isChasing = value;
    }

    public Vector2 MovementInput {
        get {
            return movementInput;
        }
        set {
            movementInput = new Vector2(Mathf.Clamp(value.x, -1, 1), Mathf.Clamp(value.y, -1, 1));
        }
    }

    private void Start() {
        enemyMovement = GetComponent<CharacterMovement2D>();
        enemyFacing2D = GetComponent<CharacterFacing2D>();
    }

    private void Update() {
        enemyMovement.ProcessMovementInput(movementInput);
        enemyFacing2D.UpdateFacing(movementInput);
    }
}