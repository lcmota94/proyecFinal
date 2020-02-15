using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{ public GameObject enemyPrefab;
    public Vector2 spawnRange;
    private int i = 0;

    void Start()
    {
        
        InvokeRepeating("SpawnEnemy",45f,3f);
    }    
    
    void SpawnEnemy()
    {
        if(i<1)
            //{
            Instantiate(enemyPrefab,
             new Vector3(Random.Range(
                         -spawnRange.x, spawnRange.x),
                        0,
                        Random.Range(
                         -spawnRange.y, spawnRange.y)),
                        Quaternion.identity);
            i++;
            //}
        
    }
}
