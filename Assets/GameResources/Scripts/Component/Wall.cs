using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private WallInfo wallInfo;
    public void Init(WallInfo wallInfo){
        this.wallInfo = wallInfo;
    }

    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Player")){
            Debug.Log("Player 충돌" + wallInfo.id);
            this.gameObject.SetActive(false);
        }
    }
}
