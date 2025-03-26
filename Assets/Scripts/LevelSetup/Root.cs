using Input;
using Misc;
using PlayerControl;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private InputController _input;
    [SerializeField] private PlayerPresenter _player;
    [SerializeField] private PlayerParameters _playerParameters;
    [SerializeField] private GroundDetector _playerGroundDetector;
    [SerializeField] private Rigidbody2D _playerRigidbody;

    private void Awake()
    {
        _player.Init(new Player(_input, _playerParameters, _playerGroundDetector, _playerRigidbody, _player.transform.position));
    }
}
