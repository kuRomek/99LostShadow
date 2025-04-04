using UnityEngine;

namespace CharacterControl
{
    [CreateAssetMenu(fileName = "Character parameters", menuName = "Custom objects/Character parameters", order = 51)]
    public class CharacterParameters : ScriptableObject
    {
        [SerializeField, Min(0f)] private float _maxHealth;
        [SerializeField, Min(0f)] private float _movementSpeed;
        [SerializeField, Min(0f)] private float _jumpForce;
        [SerializeField, Min(0f)] private float _baseAttackDamage; 

        public float MaxHealth => _maxHealth;
        public float MovementSpeed => _movementSpeed;
        public float JumpForce => _jumpForce;
        public float BaseAttackDamage => _baseAttackDamage;
    }
}
