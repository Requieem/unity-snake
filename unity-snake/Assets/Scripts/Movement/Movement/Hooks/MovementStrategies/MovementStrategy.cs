using UnityEngine;

public abstract class MovementStrategy : ScriptableObject
{
    public abstract Vector2 ComputeDirection(Transform origin, Transform target=null);
}
