using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerL1 : MonoBehaviour
{
    public ScoreManager sm;
    public DoorUnlock du;
    public Respawner[] respawner;
    private GameObject[] enemy;
    
    void Start()
    {
        
    }

    void Update()
    {
        SMDoorUnlock();
    }

    void SMDoorUnlock()
    {
        if(sm.score >= 100)
        {
            int AmountRespawn = respawner.Length;
            enemy = GameObject.FindGameObjectsWithTag("enemy");
            int AmountEnemy = enemy.Length;
            foreach (Respawner go1 in respawner)
            {
                go1.AmountEnemyMax = 0;
            }

            foreach (GameObject go2 in enemy)
            {
                GameObject.Destroy(go2);
            }


            du.Doorunlock();
        }
    }
}
