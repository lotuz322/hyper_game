using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEnemy : EventBase
{
    private Rigidbody enemyRigidbody;

    private void Start()
    {
        enemyRigidbody = GetComponentInParent<Rigidbody>();
    }

    public override void Execute()
    {
        enemyRigidbody.isKinematic = true;
    }
}
