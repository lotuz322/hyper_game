using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour, IControlableObjects
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Rotate(Vector3 delta, float distance)
    {
        gameObject.SetActive(true);
        transform.localScale = new Vector3(distance, transform.localScale.y, transform.localScale.z);
    }

    public void Push(float distance) => gameObject.SetActive(false);
}
