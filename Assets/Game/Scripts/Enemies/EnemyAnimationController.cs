public class EnemyAnimationController : CharacterAnimationController {
    private EnemyAIController enemyAIController;

    protected override void Awake() {
        base.Awake();
        enemyAIController = GetComponent<EnemyAIController>();
    }

    protected override void Update() {
        base.Update();
        animator.SetBool(CharacterMovementAnimationKeys.IsChasing, enemyAIController.isChasing);
    }
}