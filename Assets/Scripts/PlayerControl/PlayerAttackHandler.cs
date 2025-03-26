using AttackSystem;
using Input;
using Misc;
using StructureElements;
using System;
using UnityEngine;

namespace PlayerControl
{
    public class PlayerAttackHandler : AttackHandler, IUpdatable
    {
        private int _attackComboNumber = 0;
        private float _accumTime = 0f;
        private GroundDetector _groundDetector;

        public PlayerAttackHandler(InputController input, PlayerParameters parameters, GroundDetector groundDetector) :
            base(input, parameters)
        {
            AttackingCombo = new EventElement<int>[parameters.AttackComboElements.Length];

            for (int i = 0; i < AttackingCombo.Length; i++)
                AttackingCombo[i] = new EventElement<int>();

            _groundDetector = groundDetector;
        }

        public event Action AttackStarted;
        public event Action<bool> AttackStopped;
        public EventElement<int>[] AttackingCombo;

        public int AttackingState => _attackComboNumber;
        protected new PlayerParameters Params => base.Params as PlayerParameters;

        public void Update(float deltaTime)
        {
            if (_attackComboNumber != 0)
                _accumTime += deltaTime;

            for (int i = 0; i < Params.AttackComboElements.Length - 1; i++)
                if (_attackComboNumber == i + 1 && _accumTime - Params.AttackComboElements[i].Cooldown > Params.WaitingForComboTime)
                    StopAttack();

            if (_attackComboNumber == 3 && _accumTime >= Params.AttackComboElements[^1].Cooldown)
                StopAttack();
        }

        protected override void Attack()
        {
            if (_groundDetector.IsOnGround)
            {
                AttackCombo();

                if (_accumTime >= Params.AttackComboElements[_attackComboNumber - 1].Cooldown)
                    _accumTime = 0f;
            }
        }

        private void AttackCombo()
        {
            _attackComboNumber = (_attackComboNumber + 1) % (AttackingCombo.Length + 1);

            if (_attackComboNumber == 1)
                AttackStarted?.Invoke();

            AttackingCombo[_attackComboNumber - 1].Invoke(_attackComboNumber);
        }

        private void StopAttack()
        {
            _attackComboNumber = 0;
            _accumTime = 0f;
            AttackStopped?.Invoke(Input.PlayerCharacterVelocity != Vector2.zero);
        }
    }
}
