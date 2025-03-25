using Input;
using PlayerControl;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private InputController _input;
    [SerializeField] private PlayerPresenter _player;
    [SerializeField] private PlayerParameters _playerParameters;

    private void Awake()
    {
        _player.Init(new Player(_input, _playerParameters, _player.transform.position));
    }
}
