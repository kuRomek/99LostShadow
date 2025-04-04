using CharacterControl;

namespace PlayerControl
{
    public class PlayerPresenter : CharacterPresenter
    {
        public new Player Model => base.Model as Player;
        public new PlayerView View => base.View as PlayerView;

        public override void Enable()
        {
            base.Enable();

            if (Model != null)
            {
                Model.Movement.WalkingStateChanged += View.SetWalkingAnimation;
                Model.Movement.LookedLeft += View.MirrorCharacter;
                Model.Movement.Soaring += View.SetSoaringState;
                Model.AttackHandler.AttackStarted += View.SetAttackingState;
                Model.AttackHandler.AttackStopped += View.RemoveAttackingState;
            
                for (int i = 0; i < Model.AttackHandler.AttackingCombo.Length; i++)
                    Model.AttackHandler.AttackingCombo[i] += View.SetAttackComboAnimation;
            }
        }

        public override void Disable()
        {
            base.Disable();
            
            if (Model != null)
            {
                Model.Movement.WalkingStateChanged -= View.SetWalkingAnimation;
                Model.Movement.LookedLeft -= View.MirrorCharacter;
                Model.Movement.Soaring -= View.SetSoaringState;
                Model.AttackHandler.AttackStarted -= View.SetAttackingState;
                Model.AttackHandler.AttackStopped -= View.RemoveAttackingState;

                for (int i = 0; i < Model.AttackHandler.AttackingCombo.Length; i++)
                    Model.AttackHandler.AttackingCombo[i] -= View.SetAttackComboAnimation;
            }
        }
    }
}
