using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControlableObjects
{
    void Rotate(Vector3 delta, float distance);
    void Push(float distance);
}

