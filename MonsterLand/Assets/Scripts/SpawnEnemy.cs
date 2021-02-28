using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    Transform EnemySpawn;
    [SerializeField]
    Transform player;
    [SerializeField]
    float spawn_seconds;
    [SerializeField]
    float max_spawn_count;

    int spawn_count = 0;

    private void Update()
    {
        if (spawn_count == 0)
        {
            Repeat();
        } 
    }
    Transform Spawn_spawner()
    {
        if (player.position.x < 0)
        {
            EnemySpawn.transform.position = player.transform.position + new Vector3(Random.Range(13, 20), 0, 0);
        }
        if (player.position.y < 0)
        {
            EnemySpawn.transform.position = player.transform.position + new Vector3(0, Random.Range(13, 20), 0);
        }
        if (player.position.x > 0)
        {
            EnemySpawn.transform.position = player.transform.position + new Vector3(Random.Range(-20, -13), 0, 0);
        }
        if (player.position.y > 0)
        {
            EnemySpawn.transform.position = player.transform.position + new Vector3(0, Random.Range(-20, -13), 0);
        }
        return EnemySpawn.transform;
    }
    void Repeat() 
    {
        spawn_count += 1;
        if (spawn_count != max_spawn_count)
        {
            StartCoroutine(SpawnCD());
        }
    }
    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(spawn_seconds);
        Instantiate(EnemySpawn, Spawn_spawner().position, Spawn_spawner().rotation);
        Repeat();
    }
}
