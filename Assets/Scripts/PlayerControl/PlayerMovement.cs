using Characters;
using MovementSystem;
using UnityEngine;

namespace PlayerControl
{
    public class PlayerMovement : Movement
    {
        public PlayerMovement(CharacterParameters @params, Rigidbody2D rigidbody) : base(@params, rigidbody)
        {
        }

        public void UpdateVelocity(Vector2 inputVelocity, bool isOnGround, bool isAttackingOnGround)
        {
            if (isAttackingOnGround)
                Rigidbody.velocity = new Vector2(0f, Rigidbody.velocity.y);
            else
                UpdateVelocity(inputVelocity, isOnGround);
        }
    }
}
