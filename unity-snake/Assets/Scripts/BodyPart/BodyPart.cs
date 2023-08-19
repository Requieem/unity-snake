using UnityEngine;

public class BodyPart : Part, IBodyPart
{
    [SerializeField] protected Part m_Previous;
    [SerializeField] protected float m_Smoothing;
    public override IBodyPart Previous { get => m_Previous; set => m_Previous = (Part)value; }
    public Vector3 NextPostion
    {
        get
        {
            var offset = (Previous.Transform.position - transform.position).normalized * -m_PositionOffset;
            var nextPos = Previous.Transform.position + offset;
            return nextPos;
        }
    }

    public Quaternion NextRotation
    {
        get
        {
            var prev = Previous.Transform.rotation;
            var current = transform.rotation;
            var next = Quaternion.Lerp(current, prev, m_Smoothing);
            return next;
        }
    }

    private void Update()
    {
        if (m_Previous != null)
        {
            transform.SetPositionAndRotation(NextPostion, NextRotation);
        }
    }
}
