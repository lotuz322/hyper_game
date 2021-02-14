using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHandler : MonoBehaviour
{ 
    [SerializeField] private TypeTarget typeTarget;
    private EventBase[] events;           
    private Predicate<Transform> typeChecking;

    protected void TargetVerification(Transform targetTransform)
    {
        if (typeChecking(targetTransform))
            ExecuteAllEvents();
    }

    protected void ExecuteAllEvents()
    {
        foreach (IEvent _event in events)
        {
            _event.Execute();
        }
    }

    private void Awake()
    {
        events = GetComponentsInChildren<EventBase>();
        typeChecking = SetTypeVerification();
    }

    private Predicate<Transform> SetTypeVerification()
    {
        switch (typeTarget)
        {
            case TypeTarget.Player:    return (Transform t) => t.GetComponent<Player>();
            case TypeTarget.Enemy:     return (Transform t) => t.GetComponent<Enemy>();
            case TypeTarget.Thorn:     return (Transform t) => t.GetComponent<Thorn>();
            case TypeTarget.EnemyLose: return (Transform t) => t.CompareTag("EnemyLose");
            default: throw new ArgumentException("Недопустимый ключ");
        }
    }
}
public enum TypeTarget
{
    Player,
    Enemy,
    Thorn,
    EnemyLose
}