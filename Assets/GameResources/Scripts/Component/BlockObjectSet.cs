using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockObjectSet : MonoBehaviour
{
    [SerializeField] private Theme[] themes = null;
    public void SetBlock(BlockObjectSettingInfo settingInfo){
        if(settingInfo.themeIndex < themes.Length)
            this.themes[settingInfo.themeIndex].Init(settingInfo);
        else
            Debug.Log("SetBlock: 해당 테마가 없음 " + settingInfo.themeIndex);
    }
}
