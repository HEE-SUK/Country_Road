using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public SectionInfo CurSecInfo
    {
        get
        {
            return curSecInfo;
        }
        set
        {
            curSecInfo = value;
            EventManager.emit(EVENT_TYPE.CHANGE_SECTION, this, curSecInfo.id);
        }
    }
    [SerializeField] private ObjectScroller objectScroller = null;
    
    [Header("현재 섹션 인덱스")]
    [SerializeField] int curSecIndex = 0;

    private SectionInfo[] sectionInfos = null;
    // 현재 섹션 정보
    private SectionInfo curSecInfo = null;
    
    // Mono
    void Start()
    {
        OnEvent();
        DataSetting();
        objectScroller.Init(ScrollEndSetting);
    }
    void OnDestroy()
    {
        OffEvent();
    }

    //Init
    private void DataSetting()
    {
        this.sectionInfos = TableManager.SectionInfoTable.GetArray(curSecIndex, TableManager.SectionInfoTable.GetLength() - 1);
        this.CurSecInfo = sectionInfos[curSecIndex];
    }
    
    // ScrollEndCallBack
    private SectionInfo ScrollEndSetting(){
        curSecIndex++;
        CurSecInfo = sectionInfos[curSecIndex < sectionInfos.Length ? curSecIndex : sectionInfos.Length - 1];
        if (curSecInfo.checkPointID != "None") // Test용 
            Debug.Log("체크포인트 도달");
        // 블럭 객체들 세팅하기 
        // Debug.Log(curSecInfo.wallID);
        return CurSecInfo;
    }
    // Event
    private void OnEvent()
    {
        EventManager.on(EVENT_TYPE.TOUCH_RHYTHM, TouchRhythm);
        EventManager.on(EVENT_TYPE.WALL_BROKEN, WallBroken);
    }
    private void OffEvent()
    {
        EventManager.off(EVENT_TYPE.TOUCH_RHYTHM, this.TouchRhythm);
        EventManager.off(EVENT_TYPE.WALL_BROKEN, this.WallBroken);
    }
    private void TouchRhythm(EVENT_TYPE eventType, Component sender, object param = null)
    {
        float extraSpeed = (float)param;
        objectScroller.ChangeScollSpeed(extraSpeed, true);
    }
    private void WallBroken(EVENT_TYPE eventType, Component sender, object param = null)
    {
        WallInfo info = (WallInfo)param;
        objectScroller.ChangeScollSpeed(info.def, false);
    }
}
