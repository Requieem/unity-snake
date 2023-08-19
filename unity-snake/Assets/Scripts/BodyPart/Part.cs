using UnityEngine;

public class Part : MonoBehaviour, IBodyPart
{
    [SerializeField] protected Part m_Prefab;
    [SerializeField] protected float m_PositionOffset;
    public virtual IBodyPart Previous { get => null; set { }}
    public Transform Transform => transform;

    public void SpawnPart()
    {
        var spawnOffset = new Vector3(0f, -m_PositionOffset, 0f);
        var rotatedOffset = transform.rotation * spawnOffset;
        var spawnPos = transform.position + rotatedOffset;
        Part next = Instantiate<Part>(m_Prefab, spawnPos, transform.rotation);
        next.Previous = this;
    }
}
