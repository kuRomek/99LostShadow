using EnemyControl;
using Input;
using Misc;
using PlayerControl;
using UnityEngine;

namespace LevelSetup
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private InputController _input;
        [Header("Player")]
        [SerializeField] private PlayerPresenter _player;
        [SerializeField] private PlayerParameters _playerParameters;
        [SerializeField] private GroundDetector _playerGroundDetector;
        [SerializeField] private CircleCollider2D _playerAttackTrigger;
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [Header("Enemy")]
        [SerializeField] private EnemyPresenter _enemy;
        [SerializeField] private EnemyParameters _enemyParameters;
        [SerializeField] private GroundDetector _enemyGroundDetector;
        [SerializeField] private CircleCollider2D _enemyAttackTrigger;
        [SerializeField] private Rigidbody2D _enemyRigidbody;
        [SerializeField] private Route _enemyRoute;

        private EnemyController _enemyController;

        private void Awake()
        {
            _player.Init(new Player(
                _input,
                _playerAttackTrigger,
                _playerParameters,
                _playerGroundDetector,
                new PlayerMovement(_playerParameters, _playerRigidbody),
                _player.transform.position));

            Enemy skeletonWithLabris = new Enemy(
                _enemyAttackTrigger,
                _enemyParameters,
                _enemyGroundDetector,
                new EnemyMovement(_enemyParameters, _enemyRigidbody),
                _enemy.transform.position);

            _enemy.Init(skeletonWithLabris);

            _enemyController = new EnemyController(skeletonWithLabris, _enemyRoute);
        }

        private void OnEnable()
        {
            _enemyController.Enable();
        }

        private void OnDisable()
        {
            _enemyController.Disable();
        }
    }
}
