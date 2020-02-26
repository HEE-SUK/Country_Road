using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0;

    public void Init(float speed){
        this.speed = speed;
    }

    void Update(){
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
