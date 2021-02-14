using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyState : MonoBehaviour
{
    [SerializeField] private BaseEnemyState nextState = null;
    private Enemy thisEnemy = null;

    protected Transform EnemyTransform { get => thisEnemy.transform; }

    public abstract IEnumerator Action();

    private void Awake()
    {
        thisEnemy = GetComponentInParent<Enemy>();
        Init();
    }

    protected void NextState() => thisEnemy.SwitchToState(nextState);

    protected virtual void Init() { }

}
