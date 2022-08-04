using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float speed;

    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] int maxJumps = 2;

    public int Direction { get; private set; }

    int jumps;

    private void Awake()
    {
        Direction = 1;
    }

    public void Move(float xVel)
    {
        xVel *= speed;

        rb.velocity = new Vector2(xVel, rb.velocity.y);
    }

    void DoFlipX(float xVel)
    {
        if (xVel > .1f)
        {
            transform.rotation = Quaternion.identity;
            Direction = 1;
        }
        else if (xVel < -.1f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Direction = -1;
        }
    }

    public void TryJump()
    {
        if (jumps > 0)
            Jump();
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumps--;
    }

    private void Update()
    {
        DoFlipX(rb.velocity.x);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumps = maxJumps;
    }
}
