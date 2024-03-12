using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEscape : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public EnemyMovementFINAL movementFinal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movementFinal.onTheRun = true;
        }
    }
}

