using Characters;
using Input;
using StructureElements;

namespace AttackSystem
{
    public abstract class AttackHandler : IActivatable
    {
        private InputController _input;
        private CharacterParameters _params;

        public AttackHandler(InputController input, CharacterParameters parameters)
        {
            _input = input;
            _params = parameters;
        }

        protected CharacterParameters Params => _params;
        protected InputController Input => _input;

        public void Enable()
        {
            _input.Attacking += Attack;
        }

        public void Disable()
        {
            _input.Attacking -= Attack;
        }

        protected abstract void Attack();
    }
}
