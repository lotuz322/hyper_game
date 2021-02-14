using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLock : MonoBehaviour
{
    TouchController touchController = null;

    private void Start()
    {
        touchController = GetComponent<TouchController>();
        FindObjectOfType<Player>().reducedHitPoints += Execute;
    }

    private void Execute() 
        => StartCoroutine(WaitToSetActive());

    private IEnumerator WaitToSetActive()
    {
        touchController.enabled = false;
        yield return new WaitForSeconds(RedScreenMaker.waitTime);
        touchController.enabled = true;
    }

}
