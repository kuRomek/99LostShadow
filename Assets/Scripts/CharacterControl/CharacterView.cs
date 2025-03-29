using Misc;
using StructureElements;
using UnityEngine;

namespace CharacterControl
{
    public class CharacterView : View
    {
        [SerializeField] private Animator _animator;

        public Animator Animator => _animator;

        public void SetWalkingAnimation(bool isWalking)
        {
            _animator.SetBool(AnimatorData.Params.IsWalking, isWalking);
        }

        public void MirrorCharacter(bool isLookingleft)
        {
            transform.localScale = new Vector3(isLookingleft ? -1f : 1f, 1f, 1f);
        }

        public void SetJumpingAnimation()
        {
            _animator.SetBool(AnimatorData.Params.IsOnGround, false);
            _animator.SetTrigger(AnimatorData.Params.Jumping);
        }

        public void SetGroundedState()
        {
            _animator.SetBool(AnimatorData.Params.IsOnGround, true);
        }

        public void SetSoaringState(float verticalVelocity)
        {
            _animator.SetFloat(AnimatorData.Params.VerticalVelocity, verticalVelocity);
        }

        public void SetDyingAnimation()
        {
            _animator.SetTrigger(AnimatorData.Params.Died);
        }
    }
}
