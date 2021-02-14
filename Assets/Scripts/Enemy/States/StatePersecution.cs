using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePersecution : BaseEnemyState
{
    [SerializeField] private float speed = 0.0f;
    private Transform playerTransform = null;

    protected override void Init()
    {
        playerTransform = FindObjectOfType<Player>().transform;
    }

    public override IEnumerator Action()
    {
        yield return new WaitForMoveToPoint(EnemyTransform, playerTransform, speed);
    }
}
