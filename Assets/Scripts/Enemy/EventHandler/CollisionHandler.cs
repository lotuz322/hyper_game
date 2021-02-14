using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : BaseHandler
{
    private void OnCollisionEnter(Collision collision)
    {
        TargetVerification(collision.transform);
    }
}