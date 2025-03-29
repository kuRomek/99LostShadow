using CharacterControl;
using MovementSystem;
using System;
using UnityEngine;

namespace PlayerControl
{
    public class PlayerMovement : Movement
    {
        public PlayerMovement(CharacterParameters @params, Rigidbody2D rigidbody) : base(@params, rigidbody)
        {
        }

        public event Action<bool> WalkingStateChanged;
        public event Action<float> Soaring;
        public event Action<bool> LookedLeft;

        public override void Update(Vector2 inputVelocity, bool isOnGround, bool isAttackingOnGround = false)
        {
            if (isAttackingOnGround)
            {
                Rigidbody.velocity = new Vector2(0f, Rigidbody.velocity.y);
            }
            else
            {
                Rigidbody.velocity = new Vector2(Params.MovementSpeed * inputVelocity.x, Rigidbody.velocity.y);

                if (isOnGround)
                    WalkingStateChanged?.Invoke(inputVelocity != Vector2.zero);
                else
                    Soaring?.Invoke(Rigidbody.velocity.y);

                if (inputVelocity != Vector2.zero)
                    LookedLeft?.Invoke(inputVelocity.x < 0);
            }
        }
    }
}
