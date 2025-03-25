using AttackSystem;
using Input;
using StructureElements;
using System;

namespace PlayerControl
{
    public class PlayerAttackHandler : AttackHandler, IUpdatable
    {
        private int _attackingState = 0;
        private float _accumTime = 0f;

        public PlayerAttackHandler(InputController input, PlayerParameters parameters) :
            base(input, parameters)
        {
        }

        public event Action AttackStarted;
        public event Action AttackStopped;
        public event Action AttackingCombo1;
        public event Action AttackingCombo2;
        public event Action AttackingCombo3;

        protected new PlayerParameters Parameters => base.Parameters as PlayerParameters;

        public void Update(float deltaTime)
        {
            if (_attackingState != 0)
                _accumTime += deltaTime;

            if (_attackingState == 1 && _accumTime - Parameters.AttackCombo1Cooldown > Parameters.WaitingForComboTime)
            {
                _attackingState = 0;
                _accumTime = 0f;
                AttackStopped?.Invoke();
            }
            else if (_attackingState == 2 && _accumTime - Parameters.AttackCombo2Cooldown > Parameters.WaitingForComboTime)
            {
                _attackingState = 0;
                _accumTime = 0f;
                AttackStopped?.Invoke();
            }
            else if (_attackingState == 3 && _accumTime >= Parameters.AttackComboCooldown)
            {
                _attackingState = 0;
                _accumTime = 0f;
                AttackStopped?.Invoke();
            }
        }

        protected override void Attack()
        {
            if (_attackingState == 0)
            {
                AttackCombo1();
            }
            else if (_attackingState == 1 && _accumTime >= Parameters.AttackCombo1Cooldown)
            {
                AttackCombo2();
                _accumTime = 0f;
            }
            else if (_attackingState == 2 && _accumTime >= Parameters.AttackCombo2Cooldown)
            {
                AttackCombo3();
                _accumTime = 0f;
            }
        }

        private void AttackCombo1()
        {
            _attackingState = 1;
            AttackStarted?.Invoke();
            AttackingCombo1?.Invoke();
        }

        private void AttackCombo2()
        {
            _attackingState = 2;
            AttackingCombo2?.Invoke();
        }

        private void AttackCombo3()
        {
            _attackingState = 3;
            AttackingCombo3?.Invoke();
        }
    }
}
