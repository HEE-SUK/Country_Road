using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0f;

    public void Init(float enemySpeed, float carSpeed){ // 좀비 테이블 속도 전달 // ex) 0.2f
        this.speed = enemySpeed * carSpeed; // 60 은 차량 최대 속도 TODO: 차량 데이터에서 최고속도를 60 대신 대체하기.
        Debug.Log(this.speed);
    }

    void Update(){
        float curSpeed = GameManager.GameSpeed - speed;
        if(transform.position.z < -80 && curSpeed > 0)
            return;
        transform.Translate(Vector3.back * curSpeed * Time.deltaTime);
    }
}
