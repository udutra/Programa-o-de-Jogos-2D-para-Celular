using System;
using UnityEngine;

public class DeathOnDamage : MonoBehaviour, IDamageable {
    
    public event Action DeathEvent;

    public bool IsAlive {  get; private set; } = true;
    public Action OnDeath {
        get;
        set;
    }

    public void TakeDamage(int damage) {
       Die();
    }

    private void Die() {
        if(IsAlive) {
            IsAlive = false;
            OnDeath?.Invoke();
        };
    }

    /*public bool IsDead {
        get; private set;
    }

    public Action OnDeath {
        get; set;
    }

    public void TakeDamage(int damage) {
        IsDead = true;
        DeathEvent.Invoke();
    }

    private void Awake() {
        IsDead = false;
    }*/


}