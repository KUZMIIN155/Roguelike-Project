using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    private Controls player; //Параметр, в который назначается объект со скриптом Controls.
    public RespawnerHealPotion Res; //Параметр, в который назначается объект со скриптом RespawnerHealPotion.
    public int PotionHealth; //Переменная, отвечающая за кол-во восстоновляемого здоровья.

    void Start()
    {
        Res = FindObjectOfType<RespawnerHealPotion>(); ;//Присваивание Res Поиск объекта по скрипту RespawnerHealPotion
        player = FindObjectOfType<Controls>();//Присваивание player Поиск объекта по скрипту Controls
    }

    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)//Метод, срабатывающий при пресечений коллайдера с пометкой "Trigger" 
    {
        if (other.CompareTag("Player"))//По условию, метод может выполняться если коллайдер соприкасается с коллайдером объекта с тегом "player"
        {
            Res.SAmountPotionlower();//Срабатывает метод скрипта Респавнера Зелья.
            player.health += PotionHealth;//Прибавляет здоровье игроку на n кол-во.
            Destroy(gameObject);//Уничтожающий объект, то бишь зелье здоровья.
        }
    }
}
