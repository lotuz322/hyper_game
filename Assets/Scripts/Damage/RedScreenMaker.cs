using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedScreenMaker : MonoBehaviour
{
    [SerializeField] private Color makerColor;
    private Image screenMaker;
    public static float waitTime = 0.4f;

    private void Start()
    {
        screenMaker = GetComponent<Image>();
        FindObjectOfType<Player>().reducedHitPoints += RedScreen;
    }

    private void RedScreen()
    {
        screenMaker.color = makerColor;
        StartCoroutine(WaitToDisablePanel());       
    }

    private IEnumerator WaitToDisablePanel()
    {
        yield return new WaitForSeconds(waitTime);
        screenMaker.color = Color.clear;
    }
}
