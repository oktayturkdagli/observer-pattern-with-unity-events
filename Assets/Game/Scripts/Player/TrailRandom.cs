using UnityEngine;

public class TrailRandom : MonoBehaviour
{
    private TrailRenderer trailRenderer;
    private float duration;
    private float timestamp;

    private void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (Time.time > timestamp + duration)
        {
            duration = Random.Range(0.05f, 0.3f);
            timestamp = Time.time;
            trailRenderer.emitting = !trailRenderer.emitting;
        }
    }
}
