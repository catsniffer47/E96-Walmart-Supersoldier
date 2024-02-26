using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
// for final project
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb;
    Vector2 inputVector;
    private Animator anim;
    private SpriteRenderer sp;

    [SerializeField] private float speed = 1;
    [SerializeField] private float speedLimit = 5;
    [SerializeField] public float dashSpeed;
    [SerializeField] public float dashLength = .5f, dashCooldown = 1f;

    // stuff for dash

    private float activeMoveSpeed;

    private float dashCounter;
    private float dashCoolCounter;



    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        activeMoveSpeed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(x: inputVector.x * activeMoveSpeed, y: inputVector.y * activeMoveSpeed);

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

    }

    void OnMove(InputValue val)
    {
        inputVector = val.Get<Vector2>();
        Debug.Log("Moving!");
        if (inputVector != Vector2.zero)
        {
            transform.up = inputVector;
        }
    }

    void OnDash(InputValue val)
    {
        if (dashCoolCounter <= 0 && dashCounter <= 0)
        {
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
        }
    }
}
