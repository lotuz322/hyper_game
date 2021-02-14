using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateShoot : BaseEnemyState
{
    [SerializeField] private GameObject throwedObject = null;
    private Transform playerTransform = null;

    protected override void Init()
    {
        playerTransform = FindObjectOfType<Player>().transform;
    }
    public override IEnumerator Action()
    {
        transform.parent.LookAt(playerTransform.position);
        Instantiate(throwedObject, transform.parent.position, transform.parent.rotation);

        NextState();
        yield break;
    }
}
