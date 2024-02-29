using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public AudioClip shootSound;

    private AudioSource audioSource;
    private playerMovement playerMovementScript;

    private Vector3 downOffset = new Vector3(0f, -1.79f, 0f);
    private Vector3 leftOffset = new Vector3(-1.2f, -1.35f, 0f);
    private Vector3 rightOffset = new Vector3(1.2f, -1.35f, 0f);

    private bool canShoot = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMovementScript = GetComponent<playerMovement>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Vector2 movementDirection = playerMovementScript.GetMovementDirection();

            // Check if the player is moving before allowing shooting in any direction
            if (movementDirection != Vector2.zero || (movementDirection == Vector2.down))
            {
                Shoot(movementDirection);
            }
        }
    }

    void Shoot(Vector2 shootDirection)
    {
        canShoot = false; // Disable shooting until the bullet is destroyed

        // Instantiate the bullet at the adjusted firePoint position and rotation
        Vector3 adjustedFirePoint = firePoint.position;

        // Apply the offsets based on the player's movement direction
        if (shootDirection.y < 0.0f) // Down
        {
            adjustedFirePoint += downOffset;
        }
        else if (shootDirection.x < 0.0f) // Left
        {
            adjustedFirePoint += leftOffset;
        }
        else if (shootDirection.x > 0.0f) // Right
        {
            adjustedFirePoint += rightOffset;
        }

        GameObject bullet = Instantiate(bulletPrefab, adjustedFirePoint, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirection * bulletForce, ForceMode2D.Impulse);

        if (audioSource && shootSound)
        {
            audioSource.PlayOneShot(shootSound);
        }

        Destroy(bullet, 1f);

        StartCoroutine(EnableShootingAgain());
    }

    IEnumerator EnableShootingAgain()
    {
        // Wait for the bullet to be destroyed
        while (GameObject.FindWithTag("Bullet") != null)
        {
            yield return null;
        }

        // Enable shooting again
        canShoot = true;
    }
}
