using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WaitForMoveToPoint : CustomYieldInstruction
{
    private Transform thisPoint;
    private Transform targetPoint;
    private float speed;
    public override bool keepWaiting
    {
        get
        {
            MoveToPoint();
            return thisPoint.position != targetPoint.position;
        }
    }

    public WaitForMoveToPoint(Transform thisTransform, Transform targetTransform, float speed)
    {
        this.thisPoint = thisTransform;
        this.targetPoint = targetTransform;
        this.speed = speed;
    }

    private void MoveToPoint()
    {
        thisPoint.LookAt(targetPoint);
        thisPoint.position = Vector3.MoveTowards(thisPoint.position, targetPoint.position, speed * Time.deltaTime);
    }
}
