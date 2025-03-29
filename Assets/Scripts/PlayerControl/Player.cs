using Characters;
using Input;
using Misc;
using StructureElements;
using System;
using UnityEngine;

namespace PlayerControl
{
    public class Player : Character, IUpdatable, IActivatable
    {
        private readonly InputController _input;
        private readonly PlayerAttackHandler _attackHandler;
        private readonly Action _jumpingDelegate;
        private readonly Action _stoppingAttackDelegate;
        
        public Player(
            InputController input,
            CircleCollider2D attackTrigger,
            PlayerParameters parameters,
            GroundDetector groundDetector,
            PlayerMovement movement,
            Vector2 startPosition) :
            base(parameters, movement, groundDetector, startPosition)
        {
            _input = input;
            _attackHandler = new PlayerAttackHandler(parameters, attackTrigger, groundDetector);
            _jumpingDelegate = () => Movement.Jump(groundDetector.IsOnGround);
            _stoppingAttackDelegate = () => _attackHandler.StopAttack(_input.PlayerCharacterVelocity != Vector2.zero);
        }

        public PlayerAttackHandler AttackHandler => _attackHandler;
        public new PlayerMovement Movement => base.Movement as PlayerMovement;

        public void Update(float deltaTime)
        {
            _attackHandler.UpdateCooldown(deltaTime, _input.PlayerCharacterVelocity != Vector2.zero);
        }

        public override void FixedUpdate(float deltaTime)
        {
            Movement.UpdateVelocity(
                _input.PlayerCharacterVelocity,
                GroundDetector.IsOnGround,
                _attackHandler.AttackingState != 0 && _attackHandler.AttackingState != 4);
        }

        public void Enable()
        {
            _input.Attacking += _attackHandler.Attack;
            _input.Jumping += _jumpingDelegate;
            Movement.Jumped += _stoppingAttackDelegate;
        }

        public void Disable()
        {
            _input.Attacking -= _attackHandler.Attack;
            _input.Jumping -= _jumpingDelegate;
            Movement.Jumped -= _stoppingAttackDelegate;
        }
    }
}
