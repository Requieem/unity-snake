using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Moveable : MonoBehaviour
{
    [Header("Movement Setup")]
    [SerializeField] protected MovementHooks m_Hooks;
    [SerializeField] protected MovementModel m_Model;
    [SerializeField] protected MovementState m_State;

    [Header("Targeting")]
    [SerializeField] protected bool m_OverrideTarget;
    [SerializeField] protected Transform m_TargetOverride;
    [SerializeField] protected Transform m_CurrentTarget;

    protected Coroutine m_Moving;
    protected bool OverrideTarget => m_OverrideTarget;
    protected bool IsMoving => m_Moving != null && m_Moving is not null;
    protected Transform Target => OverrideTarget ? m_TargetOverride : m_CurrentTarget; 

    // Public properties polled from Model, Hook and State are used together to provide the Entity with everything it needs to execute its behaviour. These properties might seems redundant but they provide a sort of proxy so that the rest of the script is not directly dependent on the Model, Hooks and State fields. Also, external entities should not be allowed to access those three fields directly. Instead, they can access these properties which should always be available and return a value regardless.

    // Model
    public float TopSpeed => m_Model?.Speed ?? 0f;
    public float Acceleration => (m_Model?.Acceleration ?? 0f) * Time.deltaTime;

    // Hooks
    public UnityEvent<Vector2> Move => m_Hooks?.Move;
    public Vector2 Direction => m_Hooks?.ComputeDirection(transform, Target) ?? Vector2.zero;

    // State
    public float StateSpeed { get => m_State.Speed; set => m_State.Speed = value; }


    // Hook Responses
    void DoMove(Vector2 direction)
    {
        if(!IsMoving)
        {
            m_Moving = StartCoroutine(AtMove());
        }
    }

    IEnumerator AtMove()
    {
        // As long as the direction is not zero
        while (Direction != Vector2.zero)
        {
            // Move the transform along that direction
            // At the given time-scaled, increasing speed
            StateSpeed = Mathf.Clamp(StateSpeed + Acceleration, 0f, TopSpeed);
            transform.Translate(StateSpeed * Time.deltaTime * Direction, Space.World);
            yield return new WaitForEndOfFrame();
        }

        StateSpeed = 0f;
        m_Moving = null;
    }

    // Unity Callbacks
    private void OnEnable()
    {
        m_State = new MovementState(0f);
        Move?.AddListener(DoMove);
        Move.Invoke(Direction);
    }
} 
