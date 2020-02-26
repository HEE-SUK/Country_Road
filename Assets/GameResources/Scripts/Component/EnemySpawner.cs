using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{ 
    [SerializeField] EnemyController enemyController;
    public void Init(ZombieInfo zombieInfo){
        SpawnEnemy(zombieInfo);
    }
    public void SpawnEnemy(ZombieInfo zombieInfo){
        var enemy = Instantiate(enemyController,this.transform);
        enemy.Init(zombieInfo);
        enemy.gameObject.SetActive(true);
        // GameObject obj = ObjectPoolDictionary.Instance.GetObjectPrefab(zombieInfo.id);
        // if(obj == null){
        //     Debug.Log("SpawnEnemy faild: " + zombieInfo.id);
        //     return;
        // }
    }
}
