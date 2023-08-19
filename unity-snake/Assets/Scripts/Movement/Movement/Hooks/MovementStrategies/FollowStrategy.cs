using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(FollowStrategy),
    menuName = "Movement/" + AssetMenuNamingConventions.HOOK + 
               "/" + AssetMenuNamingConventions.STRATEGIES + 
               "/" + nameof(FollowStrategy),
    order = 0
)]
public class FollowStrategy : MovementStrategy
{
    public override Vector2 ComputeDirection(Transform origin, Transform target=null)
    {
        if (target is null) { return Vector2.zero; }

        var targetPos = target.position;
        var originPos = origin.position;

        return (targetPos - originPos).normalized;
    }
}
