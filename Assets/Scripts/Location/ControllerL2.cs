using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ControllerL2 : MonoBehaviour
{
    public ScoreManager sm;
    private GameObject ctr;
    private Activate final;
    private PauseMenu pauseMenu;
    public GameObject[] iface;
    private GameObject[] enemy;
    public Respawner[] respawner;
    private int UpScan = 2;

    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        ctr = GameObject.FindWithTag("Player1");
        final = FindObjectOfType<Activate>();
    }

    void Update()
    {
        Final();
        UpdateScan();
    }

    void UpdateScan()
    {
        if (UpScan >= 1)
        {
            AstarPath.active.Scan();
            UpScan --;
        }
    }

    private void Final()
    {
        if(sm.score >= 160)
        {
            int AmountRespawn = respawner.Length;
            enemy = GameObject.FindGameObjectsWithTag("enemy");
            iface = GameObject.FindGameObjectsWithTag("interface");
            int AmountEnemy = enemy.Length;
            int Amountinterface = iface.Length;

            foreach (Respawner go1 in respawner)
            {
                go1.AmountEnemyMax = 0;
            }

            foreach (GameObject go2 in enemy)
            {
                GameObject.Destroy(go2);
            }

            foreach (GameObject go3 in iface)
            {
                go3.SetActive(false);
            }

            pauseMenu.IsTrue = true;

            ctr.SetActive(false);
            final.ThisActive = true;
        }
    }
}
