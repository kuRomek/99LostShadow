using StructureElements;
using UnityEngine;

namespace PlayerControl
{
    public class PlayerView : View
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void SetWalkingAnimation(bool isWalking)
        {
            _animator.SetBool(PlayerAnimatorData.Params.IsAttacking, false);
            _animator.SetBool(PlayerAnimatorData.Params.IsWalking, isWalking);
        }

        public void MirrorSprite(bool isLookingleft)
        {
            _spriteRenderer.flipX = isLookingleft;
        }

        public void SetJumpingAnimation()
        {
            _animator.SetTrigger(PlayerAnimatorData.Params.Jumping);
        }

        public void SetAttackingState()
        {
            _animator.SetBool(PlayerAnimatorData.Params.IsAttacking, true);
        }

        public void RemoveAttackingState()
        {
            _animator.SetBool(PlayerAnimatorData.Params.IsAttacking, false);
        }

        public void SetAttackCombo1Animation()
        {
            _animator.SetTrigger(PlayerAnimatorData.Params.AttackingCombo1);
        }

        public void SetAttackCombo2Animation()
        {
            _animator.SetTrigger(PlayerAnimatorData.Params.AttackingCombo2);
        }

        public void SetAttackCombo3Animation()
        {
            _animator.SetTrigger(PlayerAnimatorData.Params.AttackingCombo3);
        }
    }
}
