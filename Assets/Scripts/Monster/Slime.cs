using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] LayerMask groundMask;

    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        if (!IsGroundExist())
        {
            Turn();
        }
    }
    public void Move()
    {
        rb.velocity = new Vector2(transform.right.x* moveSpeed, rb.velocity.y);
    }

    public void Turn()
    {
        transform.Rotate(Vector3.up, 180);
    }

    private bool IsGroundExist()
    {
        //Debug.DrawRay(groundCheckPoint.position , Vector2.down, Color.red);
        //return Physics2D.Raycast(groundCheckPoint.position, Vector2.down, 1f, groundMask);
        Debug.DrawRay(transform.position + new Vector3(transform.right.x * -1,0,0), Vector2.down, Color.red);
        return Physics2D.Raycast(transform.position + new Vector3(transform.right.x * -1, 0, 0), Vector2.down, 1f, groundMask);
    }
}
