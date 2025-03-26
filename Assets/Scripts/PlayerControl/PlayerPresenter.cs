using Misc;
using StructureElements;
using UnityEngine;

namespace PlayerControl
{
    public class PlayerPresenter : Presenter, IActivatable
    {
        [SerializeField] private GroundDetector _groundDetector;
        [SerializeField] private Rigidbody2D _rigidbody;

        public new Player Model => base.Model as Player;
        public new PlayerView View => base.View as PlayerView;

        private void Awake()
        {
            if (Model == null)
                enabled = false;
        }

        public void Enable()
        {
            Model.Movement.WalkingStateChanged += View.SetWalkingAnimation;
            Model.Movement.LookedLeft += View.MirrorSprite;
            Model.Movement.Jumped += View.SetJumpingAnimation;
            Model.Movement.Soaring += View.SetSoaringState;
            _groundDetector.HasGrounded += View.SetGroundedState;
            Model.AttackHandler.AttackStarted += View.SetAttackingState;
            Model.AttackHandler.AttackStopped += View.RemoveAttackingState;
            
            for (int i = 0; i < Model.AttackHandler.AttackingCombo.Length; i++)
                Model.AttackHandler.AttackingCombo[i] += View.SetAttackComboAnimation;
        }

        public void Disable()
        {
            Model.Movement.WalkingStateChanged -= View.SetWalkingAnimation;
            Model.Movement.LookedLeft -= View.MirrorSprite;
            Model.Movement.Jumped -= View.SetJumpingAnimation;
            Model.Movement.Soaring -= View.SetSoaringState;
            _groundDetector.HasGrounded -= View.SetGroundedState;
            Model.AttackHandler.AttackStarted -= View.SetAttackingState;
            Model.AttackHandler.AttackStopped -= View.RemoveAttackingState;

            for (int i = 0; i < Model.AttackHandler.AttackingCombo.Length; i++)
                Model.AttackHandler.AttackingCombo[i] -= View.SetAttackComboAnimation;
        }
    }
}
