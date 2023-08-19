using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

/// <summary>
/// Hooks classes are used by intra-module entities to receive and send out events that might possibly affect their behaviour, while notifying inter-module entities and other listeners of internal changes without them needing a direct dependency to the moving entities themselves.
/// </summary>
public abstract class RotationHooks : ScriptableObject
{
    [SerializeField] protected UnityEvent<Vector2> m_Rotate = new();
    public UnityEvent<Vector2> Rotate => m_Rotate;

    public abstract Vector2 ComputeDirection(Transform requester, Transform target = null);
}