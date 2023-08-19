using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Hooks classes are used by intra-module entities to receive and send out events that might possibly affect their behaviour, while notifying inter-module entities and other listeners of internal changes without them needing a direct dependency to the moving entities themselves.
/// </summary>
public abstract class MovementHooks : ScriptableObject
{
    [SerializeField] protected UnityEvent<Vector2> m_Move = new();
    [SerializeField] protected UnityEvent<float> m_SpeedChange = new();

    public UnityEvent<Vector2> Move => m_Move;
    public UnityEvent<float> SpeedChange => m_SpeedChange;

    /// <summary>
    /// Returns the Vector2 representing the value of the Direction.
    /// </summary>
    /// <param name="entity">The Transform of the GameObject requesting the direction.</param>
    /// <param name="target">The target Transform, if any.</param>
    /// <returns></returns>
    public abstract Vector2 ComputeDirection(Transform entity, Transform target=null);
}