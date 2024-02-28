using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
{
    [SerializeField] Transform spawnPosition; // transform that this thief is spawned on
    [SerializeField] public List<Transform> checkpoints; // list of checkpoints that thief will follow while idle
    [SerializeField] GameObject Thief; // no purpose yet, but holds prefab of enemy

    int activeEnemyCount = 0;
    bool levelStatus = false;
    Transform curTarg;

    void Start()
    {
        levelStatus = true;
        Instantiate(Thief, spawnPosition.position, Quaternion.identity);
        Debug.Log("A thief has been released.");
        activeEnemyCount++;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyDestroyed()
    {
        activeEnemyCount--;
    }

}

