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
    private CarInfo carInfo = null;
    
    public void Init(ZombieInfo zombieInfo,CarInfo carInfo){
        this.zombieInfo = zombieInfo;
        this.carInfo = carInfo;
        enemyMov.Init(zombieInfo.spd,carInfo.mSpd);
    }
}
