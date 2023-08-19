using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(RotationModel),
    menuName = "Rotation/" + AssetMenuNamingConventions.MODEL + "/" + AssetMenuNamingConventions.MODEL + "s/" + nameof(RotationModel),
    order = 1
)]
public class RotationModel : ScriptableObject
{
    [SerializeField][Range(0.0f, 1f)] protected float m_Smoothing = 1f;
    public float Smoothing => m_Smoothing;
}
