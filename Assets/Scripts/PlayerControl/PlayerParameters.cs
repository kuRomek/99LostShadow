using AttackSystem;
using CharacterControl;
using UnityEngine;

namespace PlayerControl
{
    [CreateAssetMenu(fileName = "Player parameters", menuName = "Custom objects/Player parameters", order = 51)]
    public class PlayerParameters : CharacterParameters
    {
        [SerializeField] private AttackComboElement[] _attackComboElements;
        [SerializeField, Min(0f)] private float _waitingForComboTime;

        public AttackComboElement[] AttackComboElements => _attackComboElements;
        public float WaitingForComboTime => _waitingForComboTime;

        private void OnValidate()
        {
            for (int i = 0; i < _attackComboElements.Length; i++)
                _attackComboElements[i].CalculateDamage(BaseAttackDamage);
        }
    }
}
