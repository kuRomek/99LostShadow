using Input;
using StructureElements;
using System;
using UnityEngine;

namespace PlayerControl
{
    public class Player : Transformable, IActivatable, IUpdatable, IFixedUpdatable
    {
        private readonly InputController _input;
        private readonly PlayerParameters _parameters;
        private readonly PlayerAttackHandler _attackHandler;
        private Vector2 _lastFrameVelocity = Vector2.zero;

        public Player(InputController input, PlayerParameters parameters, Vector2 startPosition) :
            base(position: startPosition)
        {
            _input = input;
            _parameters = parameters;
            _attackHandler = new PlayerAttackHandler(_input, _parameters);
        }

        public event Action<float> Jumped;
        public event Action<bool> WalkingStateChanged;
        public event Action<bool> LookedLeft;

        public PlayerAttackHandler AttackHandler => _attackHandler;

        public void Update(float deltaTime)
        {
            _attackHandler.Update(deltaTime);
        }

        public void FixedUpdate(float deltaTime)
        {
            MoveTo(Position + _parameters.MovementSpeed * deltaTime * _input.PlayerCharacterVelocity);

            if (_input.PlayerCharacterVelocity != _lastFrameVelocity)
                WalkingStateChanged?.Invoke(_input.PlayerCharacterVelocity != Vector2.zero);

            LookedLeft?.Invoke(_input.PlayerCharacterVelocity.x < 0);

            _lastFrameVelocity = _input.PlayerCharacterVelocity;
        }

        public void Enable()
        {
            _attackHandler.Enable();

            _input.Jumping += Jump;
        }

        public void Disable()
        {
            _attackHandler.Disable();

            _input.Jumping -= Jump;
        }

        private void Jump()
        {
            Jumped?.Invoke(_parameters.JumpForce);
        }
    }
}
