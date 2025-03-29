using Input;
using Misc;
using PlayerControl;
using UnityEngine;

namespace LevelSetup
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private InputController _input;
        [SerializeField] private PlayerPresenter _player;
        [SerializeField] private PlayerParameters _playerParameters;
        [SerializeField] private GroundDetector _playerGroundDetector;
        [SerializeField] private CircleCollider2D _playerAttackTrigger;
        [SerializeField] private Rigidbody2D _playerRigidbody;

        private void Awake()
        {
            _player.Init(new Player(
                _input,
                _playerAttackTrigger,
                _playerParameters,
                _playerGroundDetector,
                new PlayerMovement(_playerParameters, _playerRigidbody),
                _player.transform.position));
        }
    }
}
