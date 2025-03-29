using CharacterControl;
using Misc;
using System;
using UnityEngine;

namespace EnemyControl
{
    public class Enemy : Character
    {
        private readonly EnemyAttackHandler _attackHandler;
        private readonly Action _jumpingDelegate;
        private readonly Action _stoppingAttackDelegate;
        private Transform _target;

        public Enemy(
            CircleCollider2D attackTrigger,
            EnemyParameters parameters,
            GroundDetector groundDetector,
            EnemyMovement movement,
            Vector2 startPosition) :
            base(parameters, movement, groundDetector, startPosition)
        {
            _attackHandler = new EnemyAttackHandler(parameters, attackTrigger, groundDetector);
            _jumpingDelegate = () => Movement.Jump(groundDetector.IsOnGround);
            _stoppingAttackDelegate = () => _attackHandler.StopAttack();
        }

        public event Action ReachedCheckpoint;

        public EnemyAttackHandler AttackHandler => _attackHandler;
        public new EnemyMovement Movement => base.Movement as EnemyMovement;

        public void Update(float deltaTime)
        {
            _attackHandler.UpdateCooldown(deltaTime);
        }

        public override void FixedUpdate(float deltaTime)
        {
            Vector2 nextPosition =
                new Vector2(
                    Mathf.MoveTowards(Position.x, _target.position.x, Params.MovementSpeed * deltaTime),
                    Position.y);

            MoveTo(nextPosition);
            Movement.Update(nextPosition, GroundDetector.IsOnGround, _attackHandler.IsAttacking);

            if (Position.x == _target.position.x)
                ReachedCheckpoint?.Invoke();
        }

        public void Enable()
        {
            Movement.Jumped += _stoppingAttackDelegate;
        }

        public void Disable()
        {
            Movement.Jumped -= _stoppingAttackDelegate;
        }

        public void ChangeTarget(Transform target)
        {
            _target = target;
        }
    }
}
