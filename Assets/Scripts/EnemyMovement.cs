using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform spawnPosition; // refers to spawnposition set by corresponding enemyspawn
    List<Transform> checkpoints; // corresponds to list of checkpoints defined by enemyspawn
    [SerializeField] float moveSpeed = 1.0f; // thief movement speed

    int curCheckpoint = 0; // checkpoint count used to iterate
    Transform curTarg; // current position to follow
    EnemySpawner1 Spawnpoint; // reference to thief spawn posiiton

    void Start()
    {
        try
        {
            Spawnpoint = GameObject.FindObjectOfType<EnemySpawner1>();
            checkpoints = Spawnpoint.checkpoints;
            curTarg = checkpoints[curCheckpoint];
        }
        catch
        {
            Debug.LogError("bro what the heck you're missing something");
            curTarg = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(curTarg.position.x, curTarg.position.y, transform.position.z), moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, curTarg.position) < 0.1f)
        {
            SwitchCheckpoints();
        }
    }

    void SwitchCheckpoints()
    {
        curCheckpoint++;
        if (curCheckpoint >= checkpoints.Count && Vector3.Distance(transform.position, curTarg.position) < 0.1f)
        {
            curCheckpoint = 0; // resets to first checkpoint to represent that infinite loopish
        }
        curTarg = checkpoints[curCheckpoint];
    }

    private void OnDestroy()
    {
        Spawnpoint.EnemyDestroyed();
    }



}
