using Characters;
using UnityEngine;

namespace PlayerControl
{
    [CreateAssetMenu(fileName = "Player parameters", menuName = "Custom objects/Player parameters", order = 51)]
    public class PlayerParameters : CharacterParameters
    {
        [Header("Damage")]
        [SerializeField, Min(0f)] private float _attackCombo1DamageMultiplier;
        [SerializeField, Min(0f)] private float _attackCombo2DamageMultiplier;
        [SerializeField, Min(0f)] private float _attackCombo3DamageMultiplier;
        [Header("Cooldowns")]
        [SerializeField, Min(0f)] private float _attackCombo1Cooldown;
        [SerializeField, Min(0f)] private float _attackCombo2Cooldown;
        [SerializeField, Min(0f)] private float _attackComboCooldown;
        [SerializeField, Min(0f)] private float _waitingForComboTime;

        public float AttackCombo1Damage { get; private set; }
        public float AttackCombo2Damage { get; private set; }
        public float AttackCombo3Damage { get; private set; }
        public float AttackCombo1Cooldown => _attackCombo1Cooldown;
        public float AttackCombo2Cooldown => _attackCombo2Cooldown;
        public float AttackComboCooldown => _attackComboCooldown;
        public float WaitingForComboTime => _waitingForComboTime;

        private void OnValidate()
        {
            AttackCombo1Damage = BaseAttackDamage * _attackCombo1DamageMultiplier;
            AttackCombo2Damage = BaseAttackDamage * _attackCombo2DamageMultiplier;
            AttackCombo3Damage = BaseAttackDamage * _attackCombo3DamageMultiplier;
        }
    }
}
