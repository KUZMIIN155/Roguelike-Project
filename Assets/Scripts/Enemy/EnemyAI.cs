using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;//Параметр, отвечающий за объект, что будет являться целью за которой и будет движение.

    public float speed = 200f;//Параметр, отвечающий за скорость передвижения объекта. 

    public float nextWaypointDistance = 3f;//Параметр, отвечающий за расстояние до новой рассчитаной точки.

    Path path;//Отвечающий за компонент path
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;//Параметр, отвечающий за действительнойсть достигнутой точки.

    Seeker seeker;//
    Rigidbody2D rb;//

    public GameObject player;//

    [Header("Debug Setting")]
    public float normalSpeed;
    public float stopTime;
    public float startStopTime;

    void Start()
    {
        player = GameObject.FindWithTag("Player1"); //Эти два присваивания служат автоматическим поиском и назначением игрока как объект поиска и преследования.
        target = player.transform.Find("Thief");// ^^^

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        normalSpeed = speed;

        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void UpdatePath()//Отвечает за обновление расчета пути до игрока.
    {
        if (seeker.IsDone());
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    private void Stops()//Отвечает за остановку врага при получении урона.
    {
        if(stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
    }

    void OnPathComplete(Path p)//Метод, что вызывается, когда путь завершен.
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Update()//Метод MonoBehavior, что и двигает объект в направлении расчитанного пути.
    {
        if (path == null)
        {
            return;
        }
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } 
        else
        {
            reachedEndOfPath = false;
        }


        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;


        Vector2 force = direction * speed * Time.deltaTime;


        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        Stops();
    }
}
