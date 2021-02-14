using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornMovement : MonoBehaviour
{
    public Vector3 start { get; set; }
    private float maxDistance;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        maxDistance = Random.Range(14, 30);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        if ((transform.position - start).magnitude >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
