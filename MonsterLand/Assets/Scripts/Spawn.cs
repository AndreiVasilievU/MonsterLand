using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject enemy_pref;
    [SerializeField]
    float enemy_seconds;
    [SerializeField]
    float max_enemy_count;

    float enemy_count = 0;
    private void Update()
    {
        if(enemy_count == 0)
        {
            Repeat();
        }
    }
    IEnumerator SpawnCD_enemy()
    {
        yield return new WaitForSeconds(enemy_seconds);
        Instantiate(enemy_pref, transform.position, transform.rotation);
        Repeat();
    }
    void Repeat()
    {
        enemy_count += 1;
        if (enemy_count <= max_enemy_count)
        {
            StartCoroutine(SpawnCD_enemy());
        }
        if (enemy_count == max_enemy_count)
        {
            Destroy(gameObject);
        }
    }
}
