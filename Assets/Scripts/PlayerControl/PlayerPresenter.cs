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
            Model.Jumped += AddJumpingForce;
            Model.WalkingStateChanged += View.SetWalkingAnimation;
            Model.LookedLeft += View.MirrorSprite;
            Model.AttackHandler.AttackStarted += View.SetAttackingState;
            Model.AttackHandler.AttackStopped += View.RemoveAttackingState;
            Model.AttackHandler.AttackingCombo1 += View.SetAttackCombo1Animation;
            Model.AttackHandler.AttackingCombo2 += View.SetAttackCombo2Animation;
            Model.AttackHandler.AttackingCombo3 += View.SetAttackCombo3Animation;
        }

        public void Disable()
        {
            Model.Jumped -= AddJumpingForce;
            Model.WalkingStateChanged -= View.SetWalkingAnimation;
            Model.LookedLeft -= View.MirrorSprite;
            Model.AttackHandler.AttackStarted -= View.SetAttackingState;
            Model.AttackHandler.AttackStopped -= View.RemoveAttackingState;
            Model.AttackHandler.AttackingCombo1 -= View.SetAttackCombo1Animation;
            Model.AttackHandler.AttackingCombo2 -= View.SetAttackCombo2Animation;
            Model.AttackHandler.AttackingCombo3 -= View.SetAttackCombo3Animation;
        }

        private void AddJumpingForce(float jumpForce)
        {
            if (_groundDetector.IsOnGround)
            {
                View.SetJumpingAnimation();
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
