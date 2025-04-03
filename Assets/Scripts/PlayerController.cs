using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundcheck;
    public LayerMask groundlayer;

    private Rigidbody rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space) )
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }
}
