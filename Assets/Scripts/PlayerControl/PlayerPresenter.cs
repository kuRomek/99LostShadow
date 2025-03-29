using Characters;

namespace PlayerControl
{
    public class PlayerPresenter : CharacterPresenter
    {
        public new Player Model => base.Model as Player;
        public new PlayerView View => base.View as PlayerView;

        public override void Enable()
        {
            base.Enable();

            Model.AttackHandler.AttackStarted += View.SetAttackingState;
            Model.AttackHandler.AttackStopped += View.RemoveAttackingState;
            
            for (int i = 0; i < Model.AttackHandler.AttackingCombo.Length; i++)
                Model.AttackHandler.AttackingCombo[i] += View.SetAttackComboAnimation;
        }

        public override void Disable()
        {
            base.Disable();

            Model.AttackHandler.AttackStarted -= View.SetAttackingState;
            Model.AttackHandler.AttackStopped -= View.RemoveAttackingState;

            for (int i = 0; i < Model.AttackHandler.AttackingCombo.Length; i++)
                Model.AttackHandler.AttackingCombo[i] -= View.SetAttackComboAnimation;
        }
    }
}
