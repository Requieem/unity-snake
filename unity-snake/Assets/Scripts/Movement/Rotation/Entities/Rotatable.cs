using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Rotatable : MonoBehaviour
{
    [Header("Rotation Setup")]
    [SerializeField] protected RotationHooks m_Hooks;
    [SerializeField] protected RotationModel m_Model;

    protected Coroutine m_Rotating;
    protected bool IsRotating => m_Rotating != null && m_Rotating is not null;

    // Model
    public float Smoothing => m_Model?.Smoothing ?? 0f;

    // Hooks
    public UnityEvent<Vector2> Rotate => m_Hooks?.Rotate;
    public Vector2 Direction => m_Hooks?.ComputeDirection(transform) ?? Vector2.zero;

    // Hook Responses
    void DoRotate(Vector2 direction)
    {
        if(!IsRotating)
        {
            m_Rotating = StartCoroutine(AtRotate());
        }
    }

    IEnumerator AtRotate()
    {
        // As long as the direction is not zero
        while (Direction != Vector2.zero)
        {
            var angle = Vector3.SignedAngle(transform.up, Direction, Vector3.forward);

            var angleDiff = Mathf.Abs(angle - transform.rotation.z);

            var smoothedAngle = Mathf.LerpAngle(transform.rotation.z, angle, Smoothing * (360/angleDiff));

            transform.Rotate(new Vector3(0f, 0f, smoothedAngle));

            yield return new WaitForEndOfFrame();
        }

        m_Rotating = null;
    }

    // Unity Callbacks
    private void OnEnable()
    {
        Rotate?.AddListener(DoRotate);
        Rotate.Invoke(Direction);
    }
} 
