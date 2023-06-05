using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnerHealPotion : MonoBehaviour
{
    public GameObject itemRef;
    public int TimeRespawnUse;
    [SerializeField] private int AmountPotionMax;
    public int AmountPotion;
    public Transform[] spawnPoint;


    void Start()
    {
        InvokeRepeating("Respawn", TimeRespawnUse, TimeRespawnUse);
    }

    void Update()
    {
        
    }

    public void Respawn()
    {
        if (AmountPotionMax > AmountPotion)
        {
            int randSpawnPoint = Random.Range(0, spawnPoint.Length);
            GameObject potionCopy = (GameObject)Instantiate(itemRef, spawnPoint[randSpawnPoint].position, transform.rotation);
            AmountPotion += 1;
        }
    }

    public void SAmountPotionlower()
    {
        AmountPotion --;
    }

    // public Transform oldSpawnPoint;
    // public Transform[] spawnPoints;
    // public int maxTries = 50;
 
    // void SpawnEnemy(Transform _enemy)
    // {
    //     Debug.Log("Spawning Enemy: " + _enemy.name);
    //     for (int i = 0; i < maxTries; i++)
    //     {
    //         int spawnPointIndex = Random.Range(0, spawnPoints.Length);
    //         if (oldSpawnPoint != spawnPoints[spawnPointIndex])
    //         {
    //             Transform _sp = spawnPoints[spawnPointIndex)];
    //             oldSpawnPoint = _sp;
    //             Instantiate(_enemy, _sp.position, _sp.rotation);
    //             break;
    //         }
    //         else
    //         {
    //             Debug.Log("Spawning Position Already Used");
    //         }
    //     }
    // }

    // public Transform oldSpawnPoint;

    // public void Respawn()
    // {
    //     if (AmountPotionMax > AmountPotion)
    //     {
    //         int randSpawnPoint = Random.Range(0, spawnPoint.Length);
    //         if (oldSpawnPoint != spawnPoint[randSpawnPoint])
    //         {
    //             Transform _sp = spawnPoint[randSpawnPoint];
    //             oldSpawnPoint = _sp;
    //             Instantiate(itemRef, _sp.position, transform.rotation);
    //             AmountPotion += 1;
    //         }
    //     }
    // }
}
