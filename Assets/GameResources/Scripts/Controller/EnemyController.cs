using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private EnemyMovement enemyMov;
    private ZombieInfo zombieInfo;
    
    public void Init(ZombieInfo zombieInfo){
        this.zombieInfo = zombieInfo;
        enemyMov.Init(zombieInfo.spd);
    }
}
