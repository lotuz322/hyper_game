using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IControlableObjects, IPlayer
{
    [SerializeField] private float maxForce;
    [SerializeField] private float bounceForce;
    private Rigidbody playerRigidbody;
    public event Action reducedHitPoints;

    [SerializeField] private int hitPoint = 0;
    public int HitPoint 
    { 
        get => hitPoint;
        set
        {
            hitPoint -= value;
            if (hitPoint > 0)
            {
                AddUpForce();
                reducedHitPoints?.Invoke();
            }
            else 
                SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);

        }
    }

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bouncy"))
        {
            AddUpForce();
        }
    }
    
    private void AddUpForce() 
        => playerRigidbody.AddForce(Vector3.forward * bounceForce, ForceMode.Impulse);

    public void Rotate(Vector3 delta, float distance)
    {
        playerRigidbody.velocity = Vector3.zero;
        transform.rotation = Quaternion.LookRotation(delta, Vector3.up);
    }

    public void Push(float distance)
        => playerRigidbody.AddRelativeForce(Vector3.forward * maxForce * distance, ForceMode.Impulse);
}