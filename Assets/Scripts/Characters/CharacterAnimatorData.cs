using static UnityEngine.Animator;

namespace Characters
{
    public static class CharacterAnimatorData
    {
        public static class Params
        {
            public static readonly int IsWalking = StringToHash(nameof(IsWalking));
            public static readonly int Jumping = StringToHash(nameof(Jumping));
            public static readonly int IsAttacking = StringToHash(nameof(IsAttacking));
        }
    }
}
