using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{ 
    [SerializeField] 
    private EnemyController enemyController = null;
    
    public void Init(ZombieInfo zombieInfo)
    {
        SpawnEnemy(zombieInfo);
    }
    public void SpawnEnemy(ZombieInfo zombieInfo)
    {
        var enemy = Instantiate(this.enemyController, this.transform);
        enemy.Init(zombieInfo);
        enemy.gameObject.SetActive(true);
        // GameObject obj = ObjectPoolDictionary.Instance.GetObjectPrefab(zombieInfo.id);
        // if(obj == null){
        //     Debug.Log("SpawnEnemy faild: " + zombieInfo.id);
        //     return;
        // }
    }
}
