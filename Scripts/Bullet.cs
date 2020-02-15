using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject decalPrefab;
    private GameObject decalTMP;
    void OnCollisionEnter(Collision collision)
    {
        
        Destroy(this.gameObject);
    }
}
