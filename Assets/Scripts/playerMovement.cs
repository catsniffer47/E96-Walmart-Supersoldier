using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 10f; // Speed when running
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;
    
	public Vector2 GetMovementDirection()
   	{
    	return movement.normalized;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Check if the shift key is pressed to run
        float currentMoveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Apply movement with the adjusted speed
        rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);
    }
}