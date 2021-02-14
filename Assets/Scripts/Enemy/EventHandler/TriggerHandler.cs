using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : BaseHandler
{
    private void OnTriggerEnter(Collider other)
    {
        TargetVerification(other.transform);
    }
}