using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] private Transform[] _checkpoints;

    private int _currentCheckpointIndex;

    public Transform GetNextCheckpoint()
    {
        _currentCheckpointIndex = (_currentCheckpointIndex + 1) % _checkpoints.Length;
        return _checkpoints[_currentCheckpointIndex];
    }
}
