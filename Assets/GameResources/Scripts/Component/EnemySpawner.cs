using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController = null;
    [SerializeField] private Transform[] spawnPos = null;
    [SerializeField] private int maxSpawnNum = 20;

    private EnemyAttackCallBack enemyAttackCallBack = null;

    private CarInfo carInfo = null;
    private ZombieInfo zombieInfo = null;
    private SectionInfo sectionInfo = null;

    private List<EnemyController> activeList = new List<EnemyController>();
    public void Init(ZombieInfo zombieInfo, CarInfo carInfo, SectionInfo sectionInfo, EnemyAttackCallBack enemyAttackCallBack)
    {
        this.carInfo = carInfo;
        this.zombieInfo = zombieInfo;
        this.sectionInfo = sectionInfo;
        this.enemyAttackCallBack = enemyAttackCallBack;
    }
    public void SpawnEnemy(ZombieInfo zombieInfo, CarInfo carInfo)
    {
        if (maxSpawnNum < activeList.Count)
            return;
        var enemy = Instantiate(this.enemyController, this.transform);
        enemy.transform.position = spawnPos[Random.Range(0, spawnPos.Length)].position;
        enemy.Init(this.transform.position.z, zombieInfo, carInfo, enemyAttackCallBack, EnemyDie);
        activeList.Add(enemy);
        enemy.gameObject.SetActive(true);
    }
    private void EnemyDie(EnemyController enemy)
    {
        if (activeList.Contains(enemy))
            activeList.Remove(enemy);
        // Debug.Log("남은 좀비 수: " + activeList.Count);
    }
    public void SpawnLoopStart(SectionInfo sectionInfo)
    {
        StopCoroutine("SpawnLoop");
        this.sectionInfo = sectionInfo;
        this.zombieInfo = TableManager.ZombieInfoTable.GetInfo(sectionInfo.zombieID);
        StartCoroutine("SpawnLoop");
    }
    public void SpawnEnemyStop()
    {
        StopCoroutine("SpawnLoop");
    }
    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(sectionInfo.zombieInterval);
            SpawnEnemy(zombieInfo, carInfo);
            Debug.Log(zombieInfo.id);
        }
    }
}
