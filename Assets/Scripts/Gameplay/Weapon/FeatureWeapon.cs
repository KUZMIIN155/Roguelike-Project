using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureWeapon : MonoBehaviour
{
    private PlayerAttack player; //Параметр, в который назначается объект со скриптом PlayerAttack.
    public GameObject dagger; //Параметр,в который назначлся объект "dagger"
    public GameObject katana; //Параметр,в который назначлся объект "katana"

    void Start()
    {
        player = FindObjectOfType<PlayerAttack>(); //Присваивание player Поиск объекта по скрипту PlayerAttack
    }

    void Update()
    {
        if (dagger.activeSelf == true)//Проверяет, активен ли кинжал в игре.
        {
            player.damage = 10;
            player.attackRange = 12.15f;
            player.delay = 1;
        }

        if (katana.activeSelf == true)//Проверяет, активена ли катана в игре.
        {
            player.damage = 25;
            player.attackRange = 14.15f;
            player.delay = 4;
        }
    }


}
