using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterFacing2D))]
public class AIVision : MonoBehaviour {
    
    private CharacterFacing2D characterFacing;

    [Range(0.5f, 10.0f)]
    public float visionRange = 5;

    [Range(0f, 180.0f)]
    public float visionAngle = 30;

    private void Awake() {
        characterFacing = GetComponent<CharacterFacing2D>();
    }

    public bool IsVisible(GameObject target) {
        if(target == null) {
            return false;
        }

        if(Vector2.Distance(transform.position, target.transform.position) > visionRange) {
            return false;
        }

        Vector2 toTarget = target.transform.position - transform.position;
        Vector2 visionDirection = GetVisioDirection();

        if(Vector2.Angle(visionDirection, toTarget) > visionAngle / 2) {
            return false;
        }

        return true;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Vector2 visionDirection = GetVisioDirection();
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, visionAngle / 2) * visionDirection * visionRange);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, -visionAngle / 2) * visionDirection * visionRange);
    }

    private Vector2 GetVisioDirection() {
        if(characterFacing == null) {
            return Vector2.right;
        }
        return characterFacing.IsFacingRight() ? Vector2.right : Vector2.left;
    }
}
