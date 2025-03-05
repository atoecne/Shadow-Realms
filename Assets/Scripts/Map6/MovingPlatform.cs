using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] private float speed = 2f;
    private Vector2 target;
    void Start()
    {
        target = pointA.position;
    }

    // Update is called once per frame
    void Update()
    {      
        if (Vector2.Distance(transform.position, pointA.position) < 0.1f)
        {
                target = pointB.position;
        }if(Vector2.Distance(transform.position, pointB.position) < 0.1f)
        {
            target = pointA.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }

    }
}
