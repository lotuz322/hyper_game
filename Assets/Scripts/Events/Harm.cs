using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Harm : EventBase
{
    [SerializeField] private int harm;
    private Health healthBar;

    private void Start()
    {
        healthBar = FindObjectOfType<Health>();
    }

    public override void Execute()
    {
        var player = FindObjectOfType<Player>();
        player.HitPoint = harm;
    }
}
