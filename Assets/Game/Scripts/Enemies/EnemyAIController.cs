using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(CharacterFacing2D))]
[RequireComponent(typeof(IDamageable))]
public class EnemyAIController : MonoBehaviour {

    private CharacterMovement2D enemyMovement;
    private CharacterFacing2D enemyFacing2D;
    private IDamageable damageable;
    [SerializeField] private TriggerDamage damager;
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
        damageable = GetComponent<IDamageable>();
        damageable.OnDeath += OnDeath;
    }

    private void Update() {
        enemyMovement.ProcessMovementInput(movementInput);
        enemyFacing2D.UpdateFacing(movementInput);
    }

    private void OnDestroy() {
        if(damageable != null) {
            damageable.OnDeath -= OnDeath;
        }
    }

    private void OnDeath() {
        enabled = false;
        enemyMovement.StopImmediately();
        damager.gameObject.SetActive(false);
        Destroy(gameObject, 0.8f);
    }
}