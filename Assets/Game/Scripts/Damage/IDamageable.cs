using System;

public interface IDamageable {
    
    event Action DeathEvent;
    bool IsAlive { get; }
    void TakeDamage(int damage);
    Action OnDeath { get; set; }

    /*bool IsDead {
        get;
    }*/
}