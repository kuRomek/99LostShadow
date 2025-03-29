using AttackSystem;
using Misc;
using System;
using UnityEngine;

namespace PlayerControl
{
    public class PlayerAttackHandler : AttackHandler
    {
        private float _accumTime = 0f;
        private CircleCollider2D _attackTrigger;
        private GroundDetector _groundDetector;

        public PlayerAttackHandler(PlayerParameters parameters, CircleCollider2D attackTrigger, GroundDetector groundDetector) :
            base(parameters)
        {
            AttackingCombo = new EventElement<int>[parameters.AttackComboElements.Length];

            for (int i = 0; i < AttackingCombo.Length; i++)
                AttackingCombo[i] = new EventElement<int>();

            _attackTrigger = attackTrigger;
            _groundDetector = groundDetector;
        }

        public event Action AttackStarted;
        public event Action AttackStopped;
        public EventElement<int>[] AttackingCombo;

        public int AttackingState { get; private set; } = 0;
        protected new PlayerParameters Params => base.Params as PlayerParameters;

        public override void Attack()
        {
            if (_groundDetector.IsOnGround)
            {
                if (AttackingState == 0)
                {
                    AttackCombo();
                }
                else if (_accumTime >= Params.AttackComboElements[AttackingState - 1].Cooldown)
                {
                    AttackCombo();
                    _accumTime = 0f;
                }
            }
            else
            {
                AttackInJump();
            }
        }

        public void UpdateCooldown(float deltaTime)
        {
            if (AttackingState != 0)
            {
                _accumTime += deltaTime;

                if (_accumTime >= 0.2f)
                    _attackTrigger.enabled = true;

                if (AttackingState == Params.AttackComboElements.Length + 1)
                {
                    if (_groundDetector.IsOnGround)
                        StopAttack();
                }
                else if (AttackingState == Params.AttackComboElements.Length)
                {
                    if (_accumTime >= Params.AttackComboElements[^1].Cooldown)
                        StopAttack();
                }
                else if (_accumTime - Params.AttackComboElements[AttackingState - 1].Cooldown > Params.WaitingForComboTime)
                {
                    StopAttack();
                }
            }
        }

        public void StopAttack()
        {
            AttackingState = 0;
            _accumTime = 0f;
            _attackTrigger.enabled = false;
            AttackStopped?.Invoke();
        }

        private void AttackInJump()
        {
            AttackingState = Params.AttackComboElements.Length + 1;
            _accumTime = 0f;
            AttackStarted?.Invoke();
        }

        private void AttackCombo()
        {
            AttackingState = (AttackingState + 1) % (AttackingCombo.Length + 1);

            if (AttackingState == 1)
                AttackStarted?.Invoke();

            AttackingCombo[AttackingState - 1].Invoke(AttackingState);
        }
    }
}
