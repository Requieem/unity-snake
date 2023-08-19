using UnityEngine;

public class SnakeMovement : Moveable
{
    public override Vector2 Direction 
    { 
        get 
        {
            Vector2 dir = base.Direction;
            if(dir == Vector2.zero)
            {
                dir = transform.up;
            }

            return dir;
        } 
    }
} 
