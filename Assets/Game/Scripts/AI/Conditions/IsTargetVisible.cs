using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("Game/Perception/IsTargetVisible")]
public class IsTargetVisible : ConditionBase {
    public override bool Check() {
        return true;
    }
}