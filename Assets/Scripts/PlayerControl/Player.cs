using Input;
using Misc;
using StructureElements;
using UnityEngine;

namespace PlayerControl
{
    public class Player : Transformable, IActivatable, IUpdatable, IFixedUpdatable
    {
        private readonly InputController _input;
        private readonly PlayerParameters _params;
        private readonly PlayerAttackHandler _attackHandler;
        private readonly GroundDetector _groundDetector;
        private readonly PlayerMovement _movement;
        
        public Player(InputController input, PlayerParameters parameters, GroundDetector groundDetector, Rigidbody2D rigidbody, Vector2 startPosition) :
            base(position: startPosition)
        {
            _input = input;
            _params = parameters;
            _groundDetector = groundDetector;
            _attackHandler = new PlayerAttackHandler(_input, _params, groundDetector);
            _movement = new PlayerMovement(_input, _params, groundDetector, rigidbody);
        }

        public PlayerAttackHandler AttackHandler => _attackHandler;
        public PlayerMovement Movement => _movement;

        public void Update(float deltaTime)
        {
            _attackHandler.Update(deltaTime);
        }

        public void FixedUpdate(float deltaTime)
        {
            _movement.FixedUpdate(deltaTime);
        }

        public void Enable()
        {
            _attackHandler.Enable();
            _movement.Enable();
        }

        public void Disable()
        {
            _attackHandler.Disable();
            _movement.Disable();
        }
    }
}
