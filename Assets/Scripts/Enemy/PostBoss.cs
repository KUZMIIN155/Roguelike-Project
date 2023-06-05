using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostBoss : MonoBehaviour
{
    public DoorUnlock du; //Параметр, в который назначается объект со скриптом DoorUnlock.
    public GameObject boss; //Параметр, в который назначается сам босс.
    public Enemy e; //Параметр, в который назначается объект со скриптом Enemy

    void Start()
    {
        du = FindObjectOfType<DoorUnlock>();//присваивание du Поиск объекта по скрипту DoorUnlock
    }

    void Update()
    {
        DoorUnlockPostBoss(); //Постоянно обновляемы метод.
    }

    public void DoorUnlockPostBoss()//Метод с определенным условием, проверяющий параметр active в скрипте Enemy на наличие активности объекта на слое через параметр.
    {
        if (e.active == false)
        {
            du.Doorunlock();
        }
    }
}
