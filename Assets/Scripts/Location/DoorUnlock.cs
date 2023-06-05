using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Этот скрипт служит деактиватором дверей на и с локации, служащей ареной битвы с боссом.
//В основном используется для вызова в других скриптах, но все равно необходимо прикреплять к деактивируемой двери.

public class DoorUnlock : MonoBehaviour
{
    public void Doorunlock()//Cам метод деактивации объекта двери.
    {
        gameObject.SetActive(false);//Сама команда деактивации
    }
}
