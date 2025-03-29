using CharacterControl;
using System;
using UnityEngine;

namespace MovementSystem
{
    public abstract class Movement
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

        public event Action Jumped;

        protected CharacterParameters Params => _params;
        protected Rigidbody2D Rigidbody => _rigidbody;

        public abstract void Update(Vector2 input, bool isOnGround, bool isAttackingOnGround = false);

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
