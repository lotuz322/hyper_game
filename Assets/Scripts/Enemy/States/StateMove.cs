using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMove : BaseEnemyState
{
    [SerializeField] private MovingSystem movingSystem = null;
    [SerializeField] private TypeMove typeMove;
    [SerializeField] private float speed = 0.0f;

    public override IEnumerator Action()
    {
        yield return new WaitForMoveToPoint(EnemyTransform, movingSystem.GetNextPoint(typeMove), speed);
        NextState();
    }
}
