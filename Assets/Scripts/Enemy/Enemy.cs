using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    public GameObject Respawner;

    private Rigidbody2D rb;

    private ScoreManager sm;
    private Controls player1;
    private Respawner Respawn;
    public EnemyAI EAI;

    public int health;
    private float timeBtwAttack;
    public float startTimeBtwAttack; 
    public int damage;
    public bool thisBoss;
    public bool active;

    void Start()
    {
        player = GameObject.FindWithTag("Player"); 
        rb = GetComponent<Rigidbody2D>();
        sm = FindObjectOfType<ScoreManager>();
        player1 = FindObjectOfType<Controls>();
        Respawn = FindObjectOfType<Respawner>();
        EAI = GetComponent<EnemyAI>();
    }

    void Update()
    {
        Death();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(timeBtwAttack <= 0)
            {
                player1.health -= damage;
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }


    public void TakeDamage(int damage)
    {
        EAI.stopTime = EAI.startStopTime;
        health -= damage;
    }

    void Death()
    {
        if (health <= 0)
        {
            if (thisBoss == false)
            {
                sm.SKill();
                Destroy(gameObject);
                Respawn.SAmountEnemylower();
            }
            else
            {
                sm.SKill();
                gameObject.SetActive(false);
                active = false;
            }
            
        }
    }
}
