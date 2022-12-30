using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemy : MonoBehaviour
{
    [SerializeField] private GameObject dusman;

    void Start()
    {      
        InvokeRepeating("spawner", 0f,0.3f);
    }
    public void spawner()
    {       
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-12, 12), 1, Random.Range(-33, -36));       
        Instantiate(dusman, randomSpawnPosition, Quaternion.identity);     
    }
  
}
