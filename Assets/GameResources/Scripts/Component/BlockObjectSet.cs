﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockObjectSet : MonoBehaviour
{
    [SerializeField] private Transform wallPos = null;
    [SerializeField] private Theme[] themes = null;
    public void SetBlock(BlockObjectSettingInfo settingInfo){
        DisableObjectArr(themes);
        if(settingInfo.isWallActive){

            Wall activeWall = ObjectPoolDictionary.Instance.GetObjectPrefab(settingInfo.wallInfo.model).GetComponent<Wall>();
            if(activeWall == null)
                Debug.Log("this object have not WallComponent");
            activeWall.transform.SetParent(this.transform);
            activeWall.transform.position = wallPos.transform.position;
            activeWall.Init(settingInfo.wallInfo);
            activeWall.gameObject.SetActive(true);
        }
        if(settingInfo.themeIndex < themes.Length){
            this.themes[settingInfo.themeIndex].Init(settingInfo);
            this.themes[settingInfo.themeIndex].gameObject.SetActive(true);
        }
        else
            Debug.Log("SetBlock: 해당 테마가 없음 " + settingInfo.themeIndex);
    }
    private void DisableObjectArr(Theme[] objArr){
        if(objArr.Length == 0){
            Debug.Log("DisableObjectArr Failed, objArr.Length is " + objArr.Length);
            return;
        }
        for (int i = 0; i < objArr.Length; i++)
        {
            objArr[i].gameObject.SetActive(false);
        }
    }
}
