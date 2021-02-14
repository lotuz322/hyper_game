using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePush : BaseEnemyState
{
    [SerializeField] private float forceImpulse = 0.0f;
    [SerializeField] private Animator animator;
    [SerializeField] private float waitTime;
    private Transform playerTransform = null;
    private Rigidbody playerRigidbody = null;

    protected override void Init()
    {
        playerTransform = FindObjectOfType<Player>().transform;
        playerRigidbody = playerTransform.GetComponent<Rigidbody>();
    }

    public override IEnumerator Action()
    {
        animator.SetTrigger("StatePush");

        yield return new WaitForSeconds(0.2f);

        Vector3 vectorForce = (playerTransform.position - transform.position) * forceImpulse;
        playerRigidbody.AddForce(vectorForce, ForceMode.Impulse);

        NextState();
    }
}
