using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyMov = null;
    [SerializeField] private Animator anim = null;
    private ZombieInfo zombieInfo = null;
    private CarInfo carInfo = null;
    private EnemyAttackCallBack enemyAttackCallBack = null;
    private bool isAttackChance = false;
    private float hp = 0;
    public void Init(ZombieInfo zombieInfo,CarInfo carInfo,EnemyAttackCallBack enemyAttackCallBack){
        this.zombieInfo = zombieInfo;
        hp = zombieInfo.hp;
        this.carInfo = carInfo;
        this.enemyAttackCallBack = enemyAttackCallBack;
        enemyMov.Init(zombieInfo.spd,carInfo.mSpd,TryAttack);
    }

    private void TryAttack(){
        anim.SetBool("Jump",true);
        enemyAttackCallBack(zombieInfo);
    }

    public void Hurt(float demage){
        hp -= demage;
        if(hp <= 0){
            anim.SetBool("Die",true);
            anim.SetBool("Jump",false);
            gameObject.layer = 0;
            enemyMov.Die();
            Destroy(gameObject,3f);
        }
    }


}
