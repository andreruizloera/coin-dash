using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float distance = 4f;
    public float speed = 2f;
    Vector3 start;

    void Start() { start = transform.position; }

    void Update()
    {
        float x = Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        transform.position = start + Vector3.right * x;
    }
}