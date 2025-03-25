using static UnityEngine.Animator;

public static class PlayerAnimatorData
{
    public static class Params
    {
        public static readonly int IsWalking = StringToHash(nameof(IsWalking));
        public static readonly int Jumping = StringToHash(nameof(Jumping));
        public static readonly int IsAttacking = StringToHash(nameof(IsAttacking));
        public static readonly int AttackingCombo1 = StringToHash(nameof(AttackingCombo1));
        public static readonly int AttackingCombo2 = StringToHash(nameof(AttackingCombo2));
        public static readonly int AttackingCombo3 = StringToHash(nameof(AttackingCombo3));
    }
}
