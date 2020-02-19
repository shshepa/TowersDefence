using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;

    private Transform target;
    private int wavePointIndex = 0;

    void Start()
    {
        target = WayPoint.points[0];
    }
    void FixedUpdate()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }
    private void GetNextWayPoint()
    {
        if (wavePointIndex >= WayPoint.points.Length -1)
        {
            Destroy(gameObject);
        } 
        wavePointIndex++;
        target = WayPoint.points[wavePointIndex];
        
    }
}
