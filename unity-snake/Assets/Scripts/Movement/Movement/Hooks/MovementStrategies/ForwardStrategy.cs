using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(ForwardStrategy),
    menuName = "Movement/" + AssetMenuNamingConventions.HOOK + 
               "/" + AssetMenuNamingConventions.STRATEGIES + 
               "/" + nameof(ForwardStrategy),
    order = 0
)]
public class ForwardStrategy : MovementStrategy
{
    public override Vector2 ComputeDirection(Transform origin, Transform target=null)
    {
        var dir = origin.up;
        return dir;
    }
}
