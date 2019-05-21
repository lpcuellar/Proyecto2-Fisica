using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    public float speed = 0f;
    public float angle = 0f;
    public float mass;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D >();
        rb.mass = mass;

        rb.velocity = transform.right * speed;
    }



}
