using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // [SerializeField] 
    // private float speed = 0f;
    [SerializeField] 
    private EnemyMovement enemyMov = null;

    private ZombieInfo zombieInfo = null;
    
    public void Init(ZombieInfo zombieInfo){
        this.zombieInfo = zombieInfo;
        enemyMov.Init(zombieInfo.spd);
    }
}
