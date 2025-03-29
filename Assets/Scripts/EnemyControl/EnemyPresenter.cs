using CharacterControl;

namespace EnemyControl
{
    public class EnemyPresenter : CharacterPresenter
    {
        public new Enemy Model => base.Model as Enemy;
        public new EnemyView View => base.View as EnemyView;

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
            }
        }
    }
}
