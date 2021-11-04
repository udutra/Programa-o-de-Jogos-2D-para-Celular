using UnityEngine;

public class TriggerDamage : MonoBehaviour {

    [SerializeField]
    [Min(1f)]
    private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision) {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if(damageable != null) {
            damageable.TakeDamage(damage);
        }
    }
}
