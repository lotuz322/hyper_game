using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSpinPushed : BaseEnemyState
{
    [SerializeField] private float startSpeed = 0.0f;
    [SerializeField] private float spinTime = 0.0f;
    [SerializeField] private float spinSpeed = 0.0f;
    private float acceleration;

    protected override void Init()
    {
        acceleration = startSpeed / spinTime;
    }

    protected void MoveByPlayerPush()
    {
        transform.parent.position += Vector3.forward * (startSpeed - acceleration) * Time.fixedDeltaTime;
    }

    public override IEnumerator Action()
    {
        Debug.Log("Start spinning");
        var currentTime = 0.0f;
        while (currentTime <= spinTime)
        {
            currentTime += Time.fixedDeltaTime;
            MoveByPlayerPush();
            transform.parent.Rotate(Vector3.up, spinSpeed);
            yield return new WaitForFixedUpdate();
        }

        NextState();
    }
}
