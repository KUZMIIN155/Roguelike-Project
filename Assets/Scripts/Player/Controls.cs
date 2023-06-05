using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    [SerializeField] float m_speed; //скорость
    [SerializeField] private int maxHealth; //макс здоровье
    [SerializeField] public int heal; // регенерация
    public int health; //
    
    [SerializeField] private Healthbar healthbar;
    public GameObject panel;
    public GameObject pauseMenu;
    private GameObject player;

    private Rigidbody2D rb;
    private Vector2 moveVector;
    private Animator m_animator;
    public SpriteRenderer sr;
    private bool faceRight = true;
    private bool activeSelf;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        health = maxHealth;
        player = GameObject.FindWithTag("Player"); 
        InvokeRepeating("Healing", 1, 1);
    }

    void Update()
    {
        walk();
        Reflect();
        HealthbarUpdate();
    }

    void Healing()
    {
        if(health < 40)
        {
            health += heal;
        }
    }

    void HealthbarUpdate()
    {
        if (health <= 0)
            {
                health = 0;
                Death();
            }
            healthbar.UpdateHealthbar(maxHealth, health);
    }

    void Death()
    {
        if (health <= 0)
        {
            panel.SetActive(true);
            player.SetActive(false);
            pauseMenu.SetActive(false);
        }
    }

    void walk()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");
        m_animator.SetFloat("moveX", Mathf.Abs(moveVector.x));
        m_animator.SetFloat("moveY", Mathf.Abs(moveVector.y));
        rb.velocity = new Vector2(moveVector.x * m_speed, moveVector.y * m_speed);
    }

    void Reflect()
    {
        if ((moveVector.x < 0 && !faceRight) || (moveVector.x > 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

}
