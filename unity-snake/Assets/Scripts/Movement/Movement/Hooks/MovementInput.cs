using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(
    fileName = nameof(MovementInput),
    menuName = "Movement/" + AssetMenuNamingConventions.HOOK + 
               "/" + AssetMenuNamingConventions.HOOK + 
               "s/" + nameof(MovementInput),
    order = 0
)]
public class MovementInput : MovementHooks
{
    [SerializeField] protected InputActionAsset m_InputActions = null;
    void OnMove(InputAction.CallbackContext performed) { Move.Invoke(performed.ReadValue<Vector2>()); }

    private void OnEnable()
    {
        m_InputActions?.Enable();
        MoveAction.performed += OnMove;
    }

    public InputAction MoveAction => m_InputActions?.FindAction(nameof(Move));

    /// <summary>
    /// Returns the direction currently inputted in the connected Input Actions
    /// </summary>
    /// <param name="requester">The Transform of the GameObject requesting the direction.</param>
    /// <param name="target">The target Transform of the requester.</param>
    /// <returns></returns>
    public override Vector2 ComputeDirection(Transform requester, Transform target = null)
    {
        return MoveAction?.ReadValue<Vector2>() ?? Vector2.zero;
    }
}
