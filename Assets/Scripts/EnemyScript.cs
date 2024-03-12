using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Animator animator;
    public AudioClip deathSound;
    private AudioSource audioSource;
    public EnemyMovementFINAL movementFinal;

    private GameManager gameManager; // Reference to the GameManager

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            animator.SetTrigger("shot");

            if (audioSource && deathSound)
            {
                audioSource.PlayOneShot(deathSound);
            }

            Destroy(col.gameObject);
            Destroy(GetComponent<CapsuleCollider2D>());

            StartCoroutine(DestroyEnemyWithDelay());
        }
    }


    void HandleBulletHit()
    {
        animator.SetTrigger("shot");

        if (audioSource && deathSound)
        {
            audioSource.PlayOneShot(deathSound);
        }

        // Disable the collider to prevent multiple trigger calls
        GetComponent<Collider2D>().enabled = false;

        // Destroy the bullet
        Destroy(gameObject);

        StartCoroutine(DestroyEnemyWithDelay());
    }

    IEnumerator DestroyEnemyWithDelay()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        yield return new WaitForSeconds(0.5f);

        // Notify the GameManager that an enemy is destroyed
        gameManager.EnemyDestroyed();
    }
}