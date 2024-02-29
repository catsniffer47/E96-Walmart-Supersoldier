using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int totalEnemies;
    private int enemiesDestroyed;

    void Start()
    {
        // Count all enemies at the beginning
        UpdateTotalEnemiesCount();
    }

    void UpdateTotalEnemiesCount()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void EnemyDestroyed()
    {
        // Called when an enemy is destroyed
        enemiesDestroyed++;

        Debug.Log("Enemy Destroyed. Count: " + enemiesDestroyed);

        // Check if all enemies are destroyed
        if (enemiesDestroyed >= totalEnemies)
        {
            Debug.Log("All enemies destroyed. Loading End Screen.");
            // Trigger end screen or load the end scene
            SceneManager.LoadScene("End Screen");
        }
    }


    // Call this method if you dynamically add or remove enemies during the game
    public void UpdateEnemyCount()
    {
        UpdateTotalEnemiesCount();
    }
}