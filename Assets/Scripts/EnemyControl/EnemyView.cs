using CharacterControl;
using Misc;

namespace EnemyControl
{
    public class EnemyView : CharacterView
    {
        public void SetAttackingState()
        {
            Animator.SetBool(AnimatorData.Params.IsWalking, false);
            Animator.SetBool(AnimatorData.Params.IsAttacking, true);
        }

        public void RemoveAttackingState()
        {
            Animator.SetBool(AnimatorData.Params.IsAttacking, false);
        }
    }
}
