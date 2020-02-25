using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockObjectSet : MonoBehaviour
{
    [SerializeField] private Transform wallPos = null;
    [SerializeField] private Theme[] themes = null;
    public void SetBlock(BlockObjectSettingInfo settingInfo){
        DisableObjectArr(themes);
        if(settingInfo.themeIndex < themes.Length){
            this.themes[settingInfo.themeIndex].Init();
            this.themes[settingInfo.themeIndex].gameObject.SetActive(true);
        }
        else{
            Debug.Log("SetBlock: 해당 테마가 없음 " + settingInfo.themeIndex);
            this.themes[themes.Length - 1].Init();
            this.themes[themes.Length - 1].gameObject.SetActive(true);
        }
        var obj = ObjectPoolDictionary.Instance.GetObjectPrefab(settingInfo.wallInfo.model);
        obj.GetComponent<Wall>().Init(settingInfo.wallInfo);
        obj.transform.SetParent(this.transform);
        obj.transform.position = wallPos.position;
        obj.SetActive(true);
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
