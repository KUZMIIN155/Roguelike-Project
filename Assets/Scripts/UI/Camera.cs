using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]private int X_position;
    [SerializeField]private int Y_position;
    private Transform player;
    private GameObject player1;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        player1 = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = player.position.x + X_position;
        temp.y = player.position.y + Y_position;

        transform.position = temp;
    }
}
