using System;

namespace CharacterControl
{
    public class Health
    {
        private readonly int _maxAmount;

        public int Amount { get; private set; }

        public Health(int maxAmount)
        {
            _maxAmount = maxAmount;
            Amount = maxAmount;
        }

        public event Action Dying;

        public void Reduce(int amount)
        {
            if (Amount < 0)
                throw new ArgumentOutOfRangeException("reduce amount cannot be less than 0");

            Amount = (int)MathF.Max(Amount - amount, 0);

            if (Amount == 0)
                Dying?.Invoke();
        }
    }
}
