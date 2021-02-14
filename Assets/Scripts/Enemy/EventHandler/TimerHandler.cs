using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerHandler : BaseHandler
{
    [SerializeField] private float cooldownTime = 0.0f;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        var currentTime = 0.0f;
        while (currentTime <= cooldownTime)
        {
            currentTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        ExecuteAllEvents();
        StartCoroutine(Timer());
    }
}
