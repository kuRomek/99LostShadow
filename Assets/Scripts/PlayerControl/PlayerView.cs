using CharacterControl;
using Misc;
using UnityEngine;

namespace PlayerControl
{
    public class PlayerView : CharacterView
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

        public void SetAttackComboAnimation(int attackComboNumber)
        {
            Animator.SetTrigger(AnimatorData.Params.AttackingCombo[attackComboNumber - 1]);
        }
    }
}
