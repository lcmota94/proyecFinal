using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1activate : MonoBehaviour
{
      public GameObject enemyPrefab;
    public Vector2 spawnRange;
      private bool used = false;
      private int i = 0;
      

     void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
             Debug.Log ("activo");
             InvokeRepeating("SpawnEnemy",0f,3f);
             used = true;
        }
    }
    void SpawnEnemy()
    {
        if(used == false)
            {
            Instantiate(enemyPrefab,
             new Vector3(Random.Range(
                         -spawnRange.x, spawnRange.x),
                        0,
                        Random.Range(
                         -spawnRange.y, spawnRange.y)),
                        Quaternion.identity);
            
            }
        
    }
}
