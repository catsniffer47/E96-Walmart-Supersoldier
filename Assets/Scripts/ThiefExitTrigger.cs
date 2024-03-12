using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThiefExitTrigger : MonoBehaviour
{
    void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("wOah");
        if (collision.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
