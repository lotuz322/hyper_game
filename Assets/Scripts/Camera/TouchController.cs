using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TouchController : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private float maxDistance;
    private List<IControlableObjects> objectControllers;
    private Plane plane;
    private Vector3 delta;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float distance;

    void Start()
    {
        plane = new Plane(Vector3.up, Vector3.zero);

        objectControllers = new List<IControlableObjects>();
        foreach (var obj in objects)
        {
            objectControllers.Add(obj.GetComponent<IControlableObjects>());
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? point = GetPoint();
            if (point != null) 
                startPosition = (Vector3) point;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3? point = GetPoint();
            if (point != null)
                endPosition = (Vector3)point;
            
            delta = endPosition - startPosition;
            distance = Vector3.Distance(endPosition, startPosition);
            distance = ComputeForceCoef(distance);

            objectControllers.ForEach(obj => obj.Rotate(-delta, distance));
        }

        if (Input.GetMouseButtonUp(0))
            objectControllers.ForEach(obj => obj.Push(distance));
    }

    private Vector3? GetPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float enter))
            return ray.GetPoint(enter);
        return null;
    }

    private float ComputeForceCoef(float distance) 
        => Mathf.Clamp(distance, 0.0f, maxDistance);
}