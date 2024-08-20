using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    int index;

    bool isLeft;

    public Transform[] points;
    void Start()
    {
        index = Random.Range(0, points.Length);
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (isLeft == false) transform.rotation = Quaternion.Euler(0, 0, 0);
        else transform.rotation = Quaternion.Euler(0, 180, 0);

        transform.position = Vector3.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, points[index].position) < 0.2f) index = Random.Range(0, points.Length);

        if (points[index].position.x > transform.position.x) isLeft = true;
        else isLeft = false;
        
    }
}
