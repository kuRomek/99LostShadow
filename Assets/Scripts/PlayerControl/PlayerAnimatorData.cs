using static UnityEngine.Animator;

public static class PlayerAnimatorData
{
    public static class Params
    {
        public static readonly int IsWalking = StringToHash(nameof(IsWalking));
        public static readonly int Jumping = StringToHash(nameof(Jumping));
        public static readonly int IsOnGround = StringToHash(nameof(IsOnGround));
        public static readonly int VerticalVelocity = StringToHash(nameof(VerticalVelocity));
        public static readonly int IsAttacking = StringToHash(nameof(IsAttacking));

        public static readonly int[] AttackingCombo = new int[3]
        {
            StringToHash(nameof(AttackingCombo) + "1"),
            StringToHash(nameof(AttackingCombo) + "2"),
            StringToHash(nameof(AttackingCombo) + "3")
        };
    }
}
