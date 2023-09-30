using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int Health = 1;
    public Transform Target;

    public float RoatationSpeed = 0.010f;
    public float speed = 3;

    private Rigidbody2D RB;
    void Start()
    {
        RB= GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (!Target)
        {
            GetTarget();
        }
        else
        {
            RotatedTarget();
        };
    }
    private void FixedUpdate()
    {
        RB.velocity = transform.up * speed;
    }
    private void GetTarget()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;


    }

    private void RotatedTarget()
    {
        Vector2 targetDirection = Target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, RoatationSpeed);
    }
    public void takeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0) {
            Health = 0;
            Destroy(gameObject);
        }
    }
}
