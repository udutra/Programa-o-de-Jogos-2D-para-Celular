using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterFacing2D : MonoBehaviour {

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateFacing(Vector2 movimentInput) {
        if(movimentInput.x > 0) {
            spriteRenderer.flipX = false;
        }
        else if(movimentInput.x < 0) {
            spriteRenderer.flipX = true;
        }
    }

    public bool IsFacingRight() {
        return spriteRenderer.flipX == false;
    }
}