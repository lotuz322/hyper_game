using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    Vector3 delta;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        delta = player.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position - delta;
    }
}
