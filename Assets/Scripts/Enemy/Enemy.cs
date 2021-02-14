using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BaseEnemyState idel = null;
    private BaseEnemyState[] enemyStates;

    [SerializeField] private int scores;
    public int Scores
    {
        get => scores;
        set
        {
            scores = value;
        }
    }

    private void Awake()
    {
        enemyStates = GetComponentsInChildren<BaseEnemyState>();
    }

    private void Start()
    {
        SwitchToState(idel);
    }


    public void SwitchToState(BaseEnemyState nextState)
    {
        StopAllCoroutines();
        StartCoroutine(nextState.Action());
    }
}
