﻿using System.Collections;
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
    [SerializeField] private EnemySpawner enemySpawner = null;
    [SerializeField] private CarSpawner carSpawner = null;
    [SerializeField] private string testCarInfoKey = null;

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
        // objectScroller.Init(ScrollEndSetting);
    }
    void OnDestroy()
    {
        OffEvent();
    }

    //Init
    private void DataSetting()
    {
        // SectionInfo lastSecInfo = TableManager.SectionInfoTable.GetInfo(GameManager.CheckPointSecKey);
        bool isExist = TableManager.SectionInfoTable.IsExist(GameManager.CheckPointSecKey);
        this.curSecIndex = isExist ? TableManager.SectionInfoTable.GetInfo(GameManager.CheckPointSecKey).index : 0;
        this.sectionInfos = TableManager.SectionInfoTable.GetArray(curSecIndex, TableManager.SectionInfoTable.GetLength() - 1);
        this.CurSecInfo = sectionInfos[curSecIndex];
        CarInfo carInfo = TableManager.CarInfoTable.GetInfo(testCarInfoKey);
        CarController carCon = carSpawner.CarChange(carInfo.model);
        if (carCon != null)
            carCon.Init(carInfo);
        else
            Debug.Log("StartGame CarController Init faild");
    }

    // ScrollEndCallBack
    private SectionInfo ScrollEndSetting()
    {
        curSecIndex++;
        CurSecInfo = sectionInfos[curSecIndex < sectionInfos.Length ? curSecIndex : sectionInfos.Length - 1];
        enemySpawner.SpawnLoopStart(CurSecInfo);
        if (curSecInfo.checkPointID != "None")
        {
            Debug.Log("체크포인트 도달" + curSecInfo.checkPointID);
            // 체크포인트 도달 시 게임매니저에 현재 섹션 키 저장 
            GameManager.CheckPointSecKey = curSecInfo.id;
        } 
        // 블럭 객체들 세팅하기
        // Debug.Log(curSecInfo.wallID);
        return CurSecInfo;
    }
    // Attacked Car
    private void EnemyAttackCallBack(ZombieInfo zombieInfo)
    {
        objectScroller.ChangeScollSpeed(zombieInfo.atk, false);
    }
    // Event
    private void OnEvent()
    {
        EventManager.on(EVENT_TYPE.START_GAME, this.StartGame);
        EventManager.on(EVENT_TYPE.TOUCH_RHYTHM, this.TouchRhythm);
        EventManager.on(EVENT_TYPE.WALL_BROKEN, this.WallBroken);
        EventManager.on(EVENT_TYPE.FINISH_GAME, this.FinishGame);
        EventManager.on(EVENT_TYPE.CHOICE_CAR, this.ChoiceCar);
    }
    private void OffEvent()
    {
        EventManager.off(EVENT_TYPE.START_GAME, this.StartGame);
        EventManager.off(EVENT_TYPE.TOUCH_RHYTHM, this.TouchRhythm);
        EventManager.off(EVENT_TYPE.WALL_BROKEN, this.WallBroken);
        EventManager.off(EVENT_TYPE.FINISH_GAME, this.FinishGame);
        EventManager.off(EVENT_TYPE.CHOICE_CAR, this.ChoiceCar);

    }
    private void StartGame(EVENT_TYPE eventType, Component sender, object param = null)
    {
        // 게임 스타트 이벤트
        objectScroller.Init(ScrollEndSetting);
        // TODO: 시작시 자동차 정보 받기 
        enemySpawner.Init(TableManager.ZombieInfoTable.GetInfo(curSecInfo.zombieID),
            TableManager.CarInfoTable.GetInfo("C001"), curSecInfo, EnemyAttackCallBack);// 임시 자동차 정보
        enemySpawner.SpawnLoopStart(curSecInfo);
        CarInfo carInfo = TableManager.CarInfoTable.GetInfo(testCarInfoKey);
        CarController carCon = carSpawner.CarChange(carInfo.model);
        if (carCon != null)
            carCon.Init(carInfo);
        else
            Debug.Log("StartGame CarController Init faild");
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
    private void FinishGame(EVENT_TYPE eventType, Component sender, object param = null)
    {
        enemySpawner.SpawnEnemyStop();
    }
    private void ChoiceCar(EVENT_TYPE eventType, Component sender, object param = null)
    {
        Debug.Log("선택된 차: " + param.ToString());
        string infoKey = (string)param;
        CarInfo carInfo = TableManager.CarInfoTable.GetInfo(infoKey);
        CarController carCon = carSpawner.CarChange(carInfo.model);
        carCon.Init(carInfo);
    }
}
