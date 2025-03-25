using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputController : MonoBehaviour
    {
        private PlayerInput _input;

        public event Action Jumping;
        public event Action Attacking;

        public Vector2 PlayerCharacterVelocity { get; private set; }

        private void Awake()
        {
            _input = new PlayerInput();
        }

        private void OnEnable()
        {
            _input.Enable();

            _input.Player.Walking.performed += OnWalking;
            _input.Player.Walking.canceled += OnWalking;
            _input.Player.Jumping.performed += OnJumping;
            _input.Player.Attacking.performed += OnAttacked;
        }

        private void OnDisable()
        {
            _input.Disable();

            _input.Player.Walking.performed -= OnWalking;
            _input.Player.Walking.canceled -= OnWalking;
            _input.Player.Jumping.performed -= OnJumping;
        }

        private void OnWalking(InputAction.CallbackContext context)
        {
            PlayerCharacterVelocity = Vector2.right * context.action.ReadValue<float>();
        }

        private void OnJumping(InputAction.CallbackContext context)
        {
            Jumping?.Invoke();
        }

        private void OnAttacked(InputAction.CallbackContext context)
        {
            Attacking?.Invoke();
        }
    }
}
