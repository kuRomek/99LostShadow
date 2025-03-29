using AttackSystem;
using Misc;
using System;
using UnityEngine;

namespace EnemyControl
{
    public class EnemyAttackHandler : AttackHandler
    {
        private float _accumTime = 0f;
        private CircleCollider2D _attackTrigger;
        private GroundDetector _groundDetector;

        public EnemyAttackHandler(EnemyParameters parameters, CircleCollider2D attackTrigger, GroundDetector groundDetector) :
            base(parameters)
        {
            _attackTrigger = attackTrigger;
            _groundDetector = groundDetector;
        }

        public event Action AttackStarted;
        public event Action AttackStopped;

        public bool IsAttacking { get; private set; }
        protected new EnemyParameters Params => base.Params as EnemyParameters;

        public override void Attack()
        {
            if (IsAttacking == false)
            {
                IsAttacking = true;
                AttackStarted?.Invoke();
            }
        }

        public void UpdateCooldown(float deltaTime)
        {
            if (IsAttacking)
            {
                _accumTime += deltaTime;

                if (_accumTime >= 0.2f)
                    _attackTrigger.enabled = true;

                else if (_accumTime > Params.AttackCooldown)
                    StopAttack();
            }
        }

        public void StopAttack()
        {
            _accumTime = 0f;
            IsAttacking = false;
            AttackStopped?.Invoke();
        }
    }
}
