using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControllerDisabling : MonoBehaviour
{
    private TouchController touch;
    private void Start()
    {
        FindObjectOfType<Player>().reducedHitPoints += Execute;
        touch = Camera.main.GetComponent<TouchController>();
    }

    private void Execute()
    {
        touch.enabled = false;
        StartCoroutine(WaitToSetActive());
    }
    private IEnumerator WaitToSetActive()
    {
        yield return new WaitForSeconds(RedScreenMaker.waitTime);
        touch.enabled = true;
    }
}
