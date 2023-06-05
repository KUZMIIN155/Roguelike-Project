using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] public string nameR;//Переменная, отвечающая за ввод имени объекта.
    [SerializeField] private int TimeRespawnUse;//Переменная, отвечающая за периоды спавна врага.
    private UnityEngine.Object enemyRef;//Переменная, отвечающая за инициализацию объекта.
    [SerializeField] public int AmountEnemyMax;//Переменная, отвечающая за макс. кол-во спана врагов.
    public int AmountEnemy;//Переменная, отвечающая за единицу отспавненого врага.
    public Transform[] spawnPoint;//Переменная-список, Отвечающая за положение точек спана.

    void Start()
    {
        enemyRef = Resources.Load(nameR);//Инициализируется поиск объекта по переменной
        InvokeRepeating("Respawn", TimeRespawnUse, TimeRespawnUse);//С помощью повторяющегося метода, задается повтороное исползование метода через n кол-во секунд.
    }

    void Update()
    {
        
    }

    public void Respawn() //Через этот метод, по условиям происходит размещение заданных объектов.
    {
        if (AmountEnemyMax > AmountEnemy)//Через условие, задается допустимое кол-во. заспавненых prefab объектов врагов на сцене.
        {
            int randSpawnPoint = Random.Range(0, spawnPoint.Length);//Через заданную переменную, задается рандомное размещение по точкам, объектов.
            GameObject enemyCopy = (GameObject)Instantiate(enemyRef, spawnPoint[randSpawnPoint].position, transform.rotation);//Сама команда, отвечающая за спавн.
            AmountEnemy += 1;//Переменной задается то, что произошел спавн 1 объекта.
        }
    }

    public void SAmountEnemylower() //Это спец. метод, использующийся в скрипте Enemy, в котором при активации метода уничтожения объекта, происходит вычитка единицы объекта.
    {
        AmountEnemy --;
    }
}
