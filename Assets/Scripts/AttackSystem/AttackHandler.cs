using Characters;

namespace AttackSystem
{
    public abstract class AttackHandler
    {
        private CharacterParameters _params;

        public AttackHandler(CharacterParameters parameters)
        {
            _params = parameters;
        }

        protected CharacterParameters Params => _params;

        public abstract void Attack();
    }
}
