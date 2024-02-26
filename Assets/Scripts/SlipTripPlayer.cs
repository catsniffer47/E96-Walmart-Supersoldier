using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
// for final project
public class SlipTripPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb;
    Vector2 inputVector;
    private Animator anim;
    private SpriteRenderer sp;
    private Collider2D col;

    [SerializeField] private float speed = 6.05f;
    [SerializeField] private float speedLimit = 5;
    [SerializeField] public float dashSpeed;
    [SerializeField] public float dashLength = .5f, dashCooldown = 1f;

    // stuff for dash

    private float activeMoveSpeed;
    private float slowedMoveSpeed;

    private float dashCounter;
    private float dashCoolCounter;

    //stuff for collisions and turning movement on/off
    private bool isHalted = false;
    private bool isSliding = false;
    private float haltTimer = 0f;
    private float haltDuration = 2;
        void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        activeMoveSpeed = speed;
        slowedMoveSpeed = speed / 3;
 

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isSliding);
        if (isHalted == true) // hit an obstacle
        {
            //slow movement
            rb.velocity = new Vector2(x: inputVector.x * slowedMoveSpeed, y: inputVector.y * slowedMoveSpeed);
            // add time to timer
            haltTimer += Time.deltaTime;

            // Check if the halt duration has passed
            if (haltTimer >= haltDuration)
            {
                // Enable player movement again
                isHalted = false;
                // Reset the timer
                haltTimer = 0f;
            }
        }
        else if (isSliding == true) // sliding on ice
        {
            Vector2 forceDirection = inputVector*0.05f; // create force vector
            rb.AddForce(forceDirection, ForceMode2D.Impulse);
            Debug.Log("addforce");
        }
        else //normal movement
        { 
            {
                rb.velocity = new Vector2(x: inputVector.x * activeMoveSpeed, y: inputVector.y * activeMoveSpeed);
            }

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
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        Debug.Log("Moving!");



    }

    void OnDash(InputValue val)
    {
        if (dashCoolCounter <= 0 && dashCounter <= 0)
        {
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("obstacle");
            isHalted = true;

        }
        if (other.gameObject.CompareTag("slip"))
        {
            Debug.Log("slip");
            isSliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("slip"))
        {
            Debug.Log("exit");
            isSliding = false;
        }
    }
}

        

            

   
  

