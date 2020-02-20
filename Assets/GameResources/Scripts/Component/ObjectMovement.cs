using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private GameObject Wall = null;
    // 끝 위치 
    private Vector3 endPos = new Vector3(0f, 0f, 0f);
    private EndPosAction endPosAction = null;
    [SerializeField] private float testSpeed = 0f;
    public void Init(Vector3 endPos, EndPosAction endPosAction){
        this.endPos = endPos;
        this.endPosAction = endPosAction;
    }
    public void SetWallActive(bool active){
        Wall.SetActive(active);
    }
    

    void FixedUpdate()
    {
        if(transform.position.z < endPos.z){
            
        }
        transform.Translate(Vector3.back * GameManager.GameSpeed * Time.deltaTime);
    }
}
