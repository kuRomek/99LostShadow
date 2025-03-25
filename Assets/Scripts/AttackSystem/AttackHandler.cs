using Characters;
using Input;
using StructureElements;

namespace AttackSystem
{
    public abstract class AttackHandler : IActivatable
    {
        private InputController _input;
        private CharacterParameters _parameters;

        public AttackHandler(InputController input, CharacterParameters parameters)
        {
            _input = input;
            _parameters = parameters;
        }

        protected CharacterParameters Parameters => _parameters;

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
