using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(MovementModel),
    menuName = "Movement/" + AssetMenuNamingConventions.MODEL + "/" + AssetMenuNamingConventions.MODEL + "s/" + nameof(MovementModel),
    order = 1
)]
public class MovementModel : ScriptableObject
{
    [SerializeField][Range(0.1f, 10f)] protected float m_TopSpeed = 1f;
    [SerializeField][Range(0.1f, 10f)] protected float m_Acceleration = 1f;
    public float Speed => m_TopSpeed;
    public float Acceleration => m_Acceleration;
}
