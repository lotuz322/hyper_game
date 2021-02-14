 using UnityEngine;
using System.Collections;

/* Example script to apply trauma to the camera or any game object */
public class TraumaInducer : MonoBehaviour
{
    [Tooltip("Seconds to wait before trigerring the explosion particles and the trauma effect")]
    public float Delay = 1;
    [Tooltip("Maximum stress the effect can inflict upon objects Range([0,1])")]
    public float MaximumStress = 0.6f;
    [Tooltip("Maximum distance in which objects are affected by this TraumaInducer")]
    public float Range = 45;
    Transform target;
    StressReceiver receiver;
    float distance01;
    float stress;
    private void Start()
    {
        target = Camera.main.gameObject.transform;
        receiver = target.GetComponent<StressReceiver>();
        var player = FindObjectOfType<Player>();
        float distance = Vector3.Distance(player.transform.position, target.position);
        distance01 = Mathf.Clamp01(distance / Range);
        stress = (1 - Mathf.Pow(distance01, 2)) * MaximumStress;
        FindObjectOfType<Player>().reducedHitPoints += Execute;
    }
    private void Execute()
    {
        receiver.InduceStress(stress);
    }
}