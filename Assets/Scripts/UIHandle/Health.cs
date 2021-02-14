using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Slider slider;
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.reducedHitPoints += ChangeValue;

        slider = GetComponent<Slider>();
        slider.maxValue = player.HitPoint;
        slider.minValue = 0;
        slider.value = slider.maxValue;
    }
    private void ChangeValue()
    {
        slider.value = player.HitPoint;
    }
}
