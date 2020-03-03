using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    // 총구
    // [SerializeField] private Transform muzzle = null;
    [SerializeField] private GameObject muzzleParticle = null;
    // 타워 헤드
    [SerializeField] private Transform towerHead = null;
    // 사거리
    [SerializeField] private float range = 0f;
    // 적 구분용 레이어마스크
    [SerializeField] private LayerMask layerMask = 0;
    // 적 확인시 회전할 속도
    [SerializeField] private float spinSpeed = 0f;


    // 공격할 타겟
    private Transform targetTrans = null;
    private EnemyController targetEnemy = null;
    // 총알 발사 관련 
    private int bulletNum = 0;
    private int curBulletNum = 0;
    private float delayTime = 0;
    private float reloadTime = 0;
    private float demage = 0;
    // 발사 가능한지
    private bool fireActive = false;
    private ActiveCallBack activeCallBack = null;
    public void Init(int bulletNum, float delayTime, float reloadTime,float demage, ActiveCallBack activeCallBack)
    {
        this.bulletNum = bulletNum;
        this.delayTime = delayTime;
        this.reloadTime = reloadTime;
        this.curBulletNum = bulletNum;
        this.demage = demage;
        this.activeCallBack = activeCallBack;
        StartCoroutine(DelayFire(this.delayTime));
    }
    private void SearchEnemy()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, range, layerMask);
        Transform shortestTarget = null;
        if (cols.Length > 0)
        {
            float shortestDistance = Mathf.Infinity;
            for (int i = 0; i < cols.Length; i++)
            {
                float distance = Vector3.SqrMagnitude(transform.position - cols[i].transform.position);
                if (shortestDistance > distance)
                {
                    shortestDistance = distance;
                    shortestTarget = cols[i].transform;
                }
            }
        }
        targetTrans = shortestTarget;
        if(targetTrans != null)
            targetEnemy = targetTrans.GetComponent<EnemyController>();
    }

    public void SetSearchEnemyActive(bool active)
    {
        if (active)
        {
            InvokeRepeating("SearchEnemy", 0f, 0.5f);
        }
        else
        {
            CancelInvoke("SearchEnemy");
        }
    }

    private IEnumerator DelayFire(float delayTime)
    {
        while (true)
        {
            if (fireActive)
            {
                if (curBulletNum <= 0)
                {
                    activeCallBack(false);
                    muzzleParticle.SetActive(false);
                    yield return new WaitForSeconds(this.reloadTime);
                    curBulletNum = bulletNum;
                }
                activeCallBack(targetTrans == null ? false : true);
                muzzleParticle.SetActive(targetTrans == null ? false : true);
                Fire();
                yield return new WaitForSeconds(delayTime);
                muzzleParticle.SetActive(false);
            }
            yield return null;
        }
    }
    private void Fire()
    {
        curBulletNum = curBulletNum > 0 ? curBulletNum - 1 : 0;
        if(targetEnemy == null || targetEnemy.IsDie){
            return;
        }
        targetEnemy.Hurt(demage);
    }
    void Start()
    {
        SetSearchEnemyActive(true);
    }
    void Update()
    {
        if (targetTrans == null)
        {
            // towerHead.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
        }
        else
        {
            Vector3 relativePos = targetTrans.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(relativePos);
            Vector3 euler = Quaternion.RotateTowards(towerHead.rotation,
                                                    lookRotation,
                                                    spinSpeed * Time.deltaTime).eulerAngles;
            var headEuler = towerHead.rotation.eulerAngles;
            towerHead.rotation = Quaternion.Euler(headEuler.x, euler.y, headEuler.z);

            Quaternion fireRotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
            // 각도가 범위안에 들어오면 
            if (Quaternion.Angle(towerHead.rotation, fireRotation) < 0.5f)
            {
                fireActive = true;
            }
            else
            {
                fireActive = false;
            }
        }
    }
}
