using CharacterControl;
using MovementSystem;
using System;
using UnityEngine;

namespace EnemyControl
{
    public class EnemyMovement : Movement
    {
        private Vector2 _lastPosition;

        public EnemyMovement(CharacterParameters @params, Rigidbody2D rigidbody) : base(@params, rigidbody)
        {
        }

        public event Action<bool> WalkingStateChanged;
        public event Action<float> Soaring;
        public event Action<bool> LookedLeft;

        public override void Update(Vector2 inputPosition, bool isOnGround, bool isAttackingOnGround = false)
        {
            if (isAttackingOnGround == false)
            {
                if (isOnGround)
                    WalkingStateChanged?.Invoke(_lastPosition.x != inputPosition.x);
                else
                    Soaring?.Invoke(Rigidbody.velocity.y);

                if (_lastPosition.x != inputPosition.x)
                    LookedLeft?.Invoke(inputPosition.x < _lastPosition.x);

                _lastPosition = inputPosition;
            }
        }
    }
}
