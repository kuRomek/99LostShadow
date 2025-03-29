using EnemyControl;
using StructureElements;
using System;

public class EnemyController : IActivatable
{
    private readonly Enemy _enemy;
    private readonly Route _route;
    private readonly Action _changingTargetDelegate;

    public EnemyController(Enemy enemy, Route route)
    {
        _enemy = enemy;
        _route = route;
        _changingTargetDelegate = () => _enemy.ChangeTarget(_route.GetNextCheckpoint());
        _changingTargetDelegate.Invoke();
    }

    public void Enable()
    {
        _enemy.ReachedCheckpoint += _changingTargetDelegate;
    }

    public void Disable()
    {
        _enemy.ReachedCheckpoint -= _changingTargetDelegate;
    }
}
