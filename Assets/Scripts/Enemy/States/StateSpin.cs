using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSpin : BaseEnemyState
{
    [SerializeField] protected float spinTime = 0.0f;
    [SerializeField] private float spinSpeed = 0.0f;

    public override IEnumerator Action()
    {
        var currentTime = 0.0f;
        while (currentTime <= spinTime)
        {
            currentTime += Time.fixedDeltaTime;
            transform.parent.Rotate(Vector3.up, spinSpeed);
            yield return new WaitForFixedUpdate();
        }

        NextState();
    }
}
