using Input;
using Misc;
using PlayerControl;
using StructureElements;
using System;
using UnityEngine;

public class PlayerMovement : IFixedUpdatable, IActivatable
{
    private InputController _input;
    private PlayerParameters _params;
    private GroundDetector _groundDetector;
    private Rigidbody2D _rigidbody;
    private Vector2 _lastFrameVelocity = Vector2.zero;

    public PlayerMovement(InputController input, PlayerParameters @params, GroundDetector groundDetector, Rigidbody2D rigidbody)
    {
        _input = input;
        _params = @params;
        _groundDetector = groundDetector;
        _rigidbody = rigidbody;
    }

    public event Action Jumped;
    public event Action<bool> WalkingStateChanged;
    public event Action<float> Soaring;
    public event Action<bool> LookedLeft;

    public void FixedUpdate(float deltaTime)
    {
        if (_input.PlayerCharacterVelocity != _lastFrameVelocity && _groundDetector.IsOnGround)
            UpdateVelocity();

        if (_input.PlayerCharacterVelocity != Vector2.zero)
            LookedLeft?.Invoke(_input.PlayerCharacterVelocity.x < 0);

        if (_groundDetector.IsOnGround == false)
            Soaring?.Invoke(_rigidbody.velocity.y);

        _lastFrameVelocity = _input.PlayerCharacterVelocity;
    }

    public void Enable()
    {
        _input.Jumping += Jump;
        _groundDetector.HasGrounded += UpdateVelocity;
    }

    public void Disable()
    {
        _input.Jumping -= Jump;
        _groundDetector.HasGrounded -= UpdateVelocity;
    }

    private void UpdateVelocity()
    {
        WalkingStateChanged?.Invoke(_input.PlayerCharacterVelocity != Vector2.zero);
        _rigidbody.velocity = new Vector2(_params.MovementSpeed * _input.PlayerCharacterVelocity.x, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (_groundDetector.IsOnGround)
        {
            _rigidbody.AddForce(Vector2.up * _params.JumpForce, ForceMode2D.Impulse);
            Jumped?.Invoke();
        }
    }
}
