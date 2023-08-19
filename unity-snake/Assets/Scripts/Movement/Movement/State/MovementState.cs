using System;
using UnityEngine;

/// <summary>
/// A struct used to represent the state of a moving 2D object.
/// As a note, mind the fact that properties are a little bit redundant in the sense they duplicate the private fields which would otherwise be unaccessible but are used arbitrarily as a style constraint.
/// This ensures that more complex structures or classes only interface with other modules through secure (and possibly programmable) properties.
/// As a matter of fact, I almost never use public fields directly.
/// </summary>

[Serializable]
public struct MovementState
{
    // Private fields
    // This will not be accessed directly outside of this state
    [SerializeField] private float m_Speed;

    // Public Properties
    // Used to access and modify the state from the outside
    public float Speed { get => m_Speed; set => m_Speed = value; }

    /// <summary>
    /// Public Constructor for MovementState structures.
    /// </summary>
    /// <param name="speed"></param>
    // Movement entity will use this to create a new state for themselves
    public MovementState(float speed)
    {
        m_Speed = speed;
    }
}
