using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Это скрипт, написаный для объекта с коллайдером. Нужен для активации босса на локации при входе на спец. арену.

public class SpawnBoss : MonoBehaviour 
{
    //public string nameR; //параметр имени, которое я буду использовать для спавна босса | НЕ ИСПОЛЬЗУЕТСЯ
    //private UnityEngine.Object enemyRef; //параметр обьекта, что я буду искать через имя | НЕ ИСПОЛЬЗУЕТСЯ
    public GameObject Boss; //параметр, к которому я назначаю объект босса сцены
    private int Once; //параметр, через который устанавливается кол-во спавна босса


    void BossActivate() //Через этот метод босс переходит в активное состояние
    {
        //GameObject Boss = (GameObject)Instantiate(enemyRef, SpawnPoint.position, transform.rotation); Достаточно полезный способ реализации для меня, который я оставил на всякий
        //Boss.name = enemyRef.name; 
        Boss.SetActive(true); //Активация босса
        Once += 1; //Кол-во активации +1
    }

    public void OnTriggerStay2D(Collider2D other)//Метод, что активируется при соприкосновений коллайдера персонажа и колладера тригера.
    {
        if (other.CompareTag("Player"))//Условие, проверяющее тег объекта.
        {
            if (Once < 1)//Условие, не позволяющее запускать активацию босса повторно.
            {
                BossActivate();//Активация метода перехода босса в актив. состояние
            }
        }
    }
}
