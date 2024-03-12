using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementFINAL : MonoBehaviour
{
    [SerializeField] public List<Transform> patrolCheckpoints; // corresponds to list of checkpoints to patrol
    [SerializeField] public List<Transform> escapeCheckpoints; // corresponds to list of checkpoints used to escape
    [SerializeField] public float moveSpeed = 1.0f; // thief movement speed
    [SerializeField] public float escapeSpeed = 5.0f; // escape speed

    int currentCheckpoint = 0; // checkpoint count used to iterate
    int currentEscapeCheckpoint = 0;
    Transform currentPointPatrol; // current position to follow
    Transform currentPointEscape; // same

    [SerializeField] public bool onTheRun = false;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        WhenMovementCalls();
    }

    public void WhenMovementCalls()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Robber_Shot") == false)
        {
            if (!onTheRun)
            {
                currentPointPatrol = patrolCheckpoints[currentCheckpoint];
                Vector3 moveDirection = currentPointPatrol.position - transform.position;
                transform.position = Vector3.MoveTowards(transform.position, currentPointPatrol.position, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, currentPointPatrol.position) < 0.1f)
                {
                    SwitchCheckpointsPatrol();
                }
                animator.SetFloat("Horizontal", moveDirection.x);
                animator.SetFloat("Vertical", moveDirection.y);
                animator.SetFloat("Speed", moveDirection.sqrMagnitude);
            }
            else
            {
                currentPointEscape = escapeCheckpoints[currentEscapeCheckpoint];
                Vector3 moveDirection = currentPointEscape.position - transform.position;
                transform.position = Vector3.MoveTowards(transform.position, currentPointEscape.position, escapeSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, currentPointEscape.position) < 0.1f)
                {
                    SwitchCheckpointsEscape();
                }
                animator.SetFloat("Horizontal", moveDirection.x);
                animator.SetFloat("Vertical", moveDirection.y);
                animator.SetFloat("Speed", moveDirection.sqrMagnitude);
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onTheRun = true;
        }
    }



    void SwitchCheckpointsPatrol()
    {
        currentCheckpoint++;
        if (currentCheckpoint >= patrolCheckpoints.Count && Vector3.Distance(transform.position, currentPointPatrol.position) < 0.1f)
        {
            currentCheckpoint = 0; // resets to first checkpoint to represent that infinite loopish
        }
        currentPointPatrol = patrolCheckpoints[currentCheckpoint];
    }

    void SwitchCheckpointsEscape()
    {
        if (currentEscapeCheckpoint < escapeCheckpoints.Count)
        {
            currentEscapeCheckpoint++;
        }
    }


}
