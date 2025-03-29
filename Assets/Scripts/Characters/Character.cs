using Interactable;
using Misc;
using MovementSystem;
using StructureElements;
using UnityEngine;

namespace Characters
{
    public abstract class Character : Transformable, IFixedUpdatable, IDamageable
    {
        private readonly CharacterParameters _params;
        private readonly Movement _movement;
        private readonly GroundDetector _groundDetector;
        private readonly Health _health;

        public Character(
            CharacterParameters parameters,
            Movement movement,
            GroundDetector groundDetector,
            Vector2 startPosition) :
            base(position: startPosition)
        {
            _params = parameters;
            _groundDetector = groundDetector;
            _health = new Health((int)_params.MaxHealth);
            _movement = movement;
        }

        public CharacterParameters Params => _params;
        public Movement Movement => _movement;
        public GroundDetector GroundDetector => _groundDetector;

        public virtual void FixedUpdate(float deltaTime)
        {
            _movement.UpdateVelocity(
                Vector2.left,
                _groundDetector.IsOnGround);
        }

        public void TakeDamage(int amount)
        {
            _health.Reduce(amount);
        }
    }
}
