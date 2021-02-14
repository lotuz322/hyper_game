using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDefeatedEnemy : BaseEnemyState
{
    public override IEnumerator Action()
    {
        var enemy = transform.parent.gameObject;
        var enemyRigidBody = enemy.AddComponent<Rigidbody>();
        enemyRigidBody.isKinematic = true;
        yield break;
    }
}
