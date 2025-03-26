using StructureElements;
using System;
using UnityEngine;

namespace PlayerControl
{
    public class PlayerView : View
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void SetWalkingAnimation(bool isWalking)
        {
            _animator.SetBool(PlayerAnimatorData.Params.IsWalking, isWalking);
        }

        public void MirrorSprite(bool isLookingleft)
        {
            _spriteRenderer.flipX = isLookingleft;
        }

        public void SetJumpingAnimation()
        {
            _animator.SetBool(PlayerAnimatorData.Params.IsOnGround, false);
            _animator.SetTrigger(PlayerAnimatorData.Params.Jumping);
        }

        public void SetAttackingState()
        {
            _animator.SetBool(PlayerAnimatorData.Params.IsWalking, false);
            _animator.SetBool(PlayerAnimatorData.Params.IsAttacking, true);
        }

        public void RemoveAttackingState(bool isWalking)
        {
            _animator.SetBool(PlayerAnimatorData.Params.IsWalking, isWalking);
            _animator.SetBool(PlayerAnimatorData.Params.IsAttacking, false);
        }

        public void SetAttackComboAnimation(int attackComboNumber)
        {
            _animator.SetTrigger(PlayerAnimatorData.Params.AttackingCombo[attackComboNumber - 1]);
        }

        public void SetGroundedState()
        {
            _animator.SetBool(PlayerAnimatorData.Params.IsOnGround, true);
        }

        public void SetSoaringState(float verticalVelocity)
        {
            _animator.SetFloat(PlayerAnimatorData.Params.VerticalVelocity, verticalVelocity);
        }
    }
}
