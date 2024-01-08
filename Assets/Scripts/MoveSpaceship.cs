using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpaceship : MonoBehaviour
{
    private float speed = 10.0f;

    private Rigidbody2D rb;

    private Vector2 movementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }   

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(movementDirection.x, movementDirection.y, 0f) * speed;
    }
}
