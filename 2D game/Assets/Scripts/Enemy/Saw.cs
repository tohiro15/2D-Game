using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    private float speed = 5f;

    private int index;

    public Transform[] points;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.instance.TakeDamage();
        }
    }
    private void Start()
    {
        index = Random.Range(0, points.Length);
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, points[index].position) < 0.2f) index = Random.Range(0, points.Length);

    }
}
