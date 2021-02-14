using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemyState : EventBase
{
    [SerializeField] private BaseEnemyState toState = null;
    private Enemy enemy = null;

    protected BaseEnemyState ToState { get => toState; }
    protected Enemy Enemy { get => enemy; }
    
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    public override void Execute()
    {
        enemy.SwitchToState(ToState);
    }
}
