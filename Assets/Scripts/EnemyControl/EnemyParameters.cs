using CharacterControl;
using UnityEngine;

namespace EnemyControl
{
    [CreateAssetMenu(fileName = "Enemy parameters", menuName = "Custom objects/Enemy parameters", order = 51)]
    public class EnemyParameters : CharacterParameters
    {
        [SerializeField, Min(0f)] private float _attackCooldown;

        public float AttackCooldown => _attackCooldown;
    }
}
