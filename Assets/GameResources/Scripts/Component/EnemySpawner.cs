using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{ 
    [SerializeField] private EnemyController enemyController = null;
    [SerializeField] private Transform[] spawnPos = null;

    private EnemyAttackCallBack enemyAttackCallBack = null;

    private CarInfo carInfo = null;
    private ZombieInfo zombieInfo = null;
    private SectionInfo sectionInfo = null;

    public void Init(ZombieInfo zombieInfo,CarInfo carInfo,SectionInfo sectionInfo,EnemyAttackCallBack enemyAttackCallBack)
    {
        this.carInfo = carInfo;
        this.zombieInfo = zombieInfo;
        this.sectionInfo = sectionInfo;
        this.enemyAttackCallBack = enemyAttackCallBack;
    }
    public void SpawnEnemy(ZombieInfo zombieInfo,CarInfo carInfo)
    {
        var enemy = Instantiate(this.enemyController, this.transform);
        enemy.transform.position = spawnPos[Random.Range(0,spawnPos.Length)].position;
        enemy.Init(zombieInfo,carInfo,enemyAttackCallBack);
        enemy.gameObject.SetActive(true);
    }

    public void SpawnLoopStart(SectionInfo sectionInfo){
        StopCoroutine("SpawnLoop");
        this.sectionInfo = sectionInfo;
        StartCoroutine("SpawnLoop");
    }
    public void SpawnEnemyStop(){
        StopCoroutine("SpawnLoop");
    }
    private IEnumerator SpawnLoop(){
        while(true){
            yield return new WaitForSeconds(sectionInfo.zombieInterval);
            SpawnEnemy(zombieInfo,carInfo);
        }
    }
}
