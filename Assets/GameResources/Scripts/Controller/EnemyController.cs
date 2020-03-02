using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool IsDie
    {
        get
        {
            return isDie;
        }
    }
    [SerializeField] private EnemyMovement enemyMov = null;
    [SerializeField] private Animator anim = null;
    [SerializeField] private ParticleSystem hitParticle = null;
    private ZombieInfo zombieInfo = null;
    private CarInfo carInfo = null;
    private EnemyAttackCallBack enemyAttackCallBack = null;
    private EnemyDieCallBack enemyDieCallBack = null;
    private bool isDie = false;
    private float hp = 0;
    public void Init(float stopPos, ZombieInfo zombieInfo, CarInfo carInfo, EnemyAttackCallBack enemyAttackCallBack, EnemyDieCallBack enemyDieCallBack)
    {
        this.zombieInfo = zombieInfo;
        this.hp = zombieInfo.hp;
        this.carInfo = carInfo;
        this.enemyAttackCallBack = enemyAttackCallBack;
        this.enemyDieCallBack = enemyDieCallBack;
        enemyMov.Init(stopPos, zombieInfo.spd, carInfo.mSpd, TryAttack);
        hitParticle.gameObject.SetActive(false);
    }

    private void TryAttack()
    {
        anim.SetBool("Jump", true);
        enemyAttackCallBack(zombieInfo);
    }

    public void Hurt(float demage)
    {
        hp -= demage;
        if (hp <= 0)
        {
            isDie = true;
            hitParticle.gameObject.SetActive(true);
            enemyDieCallBack(this);
            anim.SetBool("Die", true);
            anim.SetBool("Jump", false);
            gameObject.layer = 0;
            enemyMov.Die();
            Destroy(gameObject, 3f);
        }
    }


}
