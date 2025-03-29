using Characters;
using System;
using UnityEngine;

namespace MovementSystem
{
    public class Movement
    {
        private readonly CharacterParameters _params;
        private readonly Rigidbody2D _rigidbody;

        public Movement(
            CharacterParameters @params,
            Rigidbody2D rigidbody)
        {
            _params = @params;
            _rigidbody = rigidbody;
        }

        public event Action<bool> WalkingStateChanged;
        public event Action Jumped;
        public event Action<float> Soaring;
        public event Action<bool> LookedLeft;

        protected CharacterParameters Params => _params;
        protected Rigidbody2D Rigidbody => _rigidbody;

        public void UpdateVelocity(Vector2 inputVelocity, bool isOnGround)
        {
            _rigidbody.velocity = new Vector2(Params.MovementSpeed * inputVelocity.x, _rigidbody.velocity.y);

            if (isOnGround)
                WalkingStateChanged?.Invoke(inputVelocity != Vector2.zero);
            else
                Soaring?.Invoke(Rigidbody.velocity.y);

            if (inputVelocity != Vector2.zero)
                LookedLeft?.Invoke(inputVelocity.x < 0);
        }

        public void Jump(bool isOnGround)
        {
            if (isOnGround)
            {
                _rigidbody.AddForce(Vector2.up * _params.JumpForce, ForceMode2D.Impulse);
                Jumped?.Invoke();
            }
        }
    }
}
