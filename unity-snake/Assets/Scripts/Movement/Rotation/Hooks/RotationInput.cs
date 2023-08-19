using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(
    fileName = nameof(RotationInput),
    menuName = "Rotation/" + AssetMenuNamingConventions.HOOK + 
               "/" + AssetMenuNamingConventions.HOOK + 
               "s/" + nameof(RotationInput),
    order = 0
)]
public class RotationInput : RotationHooks
{
    [SerializeField] protected InputActionAsset m_InputActions = null;
    void OnRotate(InputAction.CallbackContext performed) { Rotate.Invoke(performed.ReadValue<Vector2>()); }

    private void OnEnable()
    {
        m_InputActions?.Enable();
        RotateAction.performed += OnRotate;
    }

    public InputAction RotateAction => m_InputActions?.FindAction(nameof(Rotate));

    /// <summary>
    /// Returns the direction currently inputted in the connected Input Actions
    /// </summary>
    /// <param name="requester">The Transform of the GameObject requesting the direction.</param>
    /// <param name="target">The target Transform of the requester.</param>
    /// <returns></returns>
    public override Vector2 ComputeDirection(Transform requester, Transform target = null)
    {
        return RotateAction?.ReadValue<Vector2>() ?? Vector2.zero;
    }
}
