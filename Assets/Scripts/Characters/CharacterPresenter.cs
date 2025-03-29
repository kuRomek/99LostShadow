using Interactable;
using Misc;
using StructureElements;
using UnityEngine;

namespace Characters
{
    public class CharacterPresenter : Presenter, IActivatable
    {
        [SerializeField] private GroundDetector _groundDetector;
        [SerializeField] private Damageable _damageable;
        [SerializeField] private Rigidbody2D _rigidbody;

        public new Character Model => base.Model as Character;
        public new CharacterView View => base.View as CharacterView;

        private void Awake()
        {
            if (Model == null)
                enabled = false;
        }

        public virtual void Enable()
        {
            Model.Movement.WalkingStateChanged += View.SetWalkingAnimation;
            Model.Movement.LookedLeft += View.MirrorCharacter;
            Model.Movement.Jumped += View.SetJumpingAnimation;
            Model.Movement.Soaring += View.SetSoaringState;
            _groundDetector.HasGrounded += View.SetGroundedState;
            _damageable.TakingDamage += Model.TakeDamage;
        }

        public virtual void Disable()
        {
            Model.Movement.WalkingStateChanged -= View.SetWalkingAnimation;
            Model.Movement.LookedLeft -= View.MirrorCharacter;
            Model.Movement.Jumped -= View.SetJumpingAnimation;
            Model.Movement.Soaring -= View.SetSoaringState;
            _groundDetector.HasGrounded -= View.SetGroundedState;
            _damageable.TakingDamage += Model.TakeDamage;
        }
    }
}
