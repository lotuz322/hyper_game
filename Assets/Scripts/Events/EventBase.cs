using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventBase : MonoBehaviour, IEvent
{
    public abstract void Execute();
}
