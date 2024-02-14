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

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(x: inputVector.x * speed, y: inputVector.y * speed);
    }

    void OnMove(InputValue val)
    {
        inputVector = val.Get<Vector2>();
        Debug.Log("Moving!");

    }
}
