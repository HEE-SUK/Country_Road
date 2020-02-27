using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{ 
    [SerializeField] 
    private EnemyController enemyController = null;
    private CarInfo carInfo = null;
    public void Init(ZombieInfo zombieInfo,CarInfo carInfo)
    {
        this.carInfo = carInfo;
        SpawnEnemy(zombieInfo,carInfo);
    }
    public void SpawnEnemy(ZombieInfo zombieInfo,CarInfo carInfo)
    {
        var enemy = Instantiate(this.enemyController, this.transform);
        enemy.Init(zombieInfo,carInfo);
        enemy.gameObject.SetActive(true);

    }
}
