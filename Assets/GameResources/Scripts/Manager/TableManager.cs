using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : Singleton<TableManager>
{
    // 'TableManager.해당테이블.GetInfo(아이디)'로 호출해서 원하는 정보 추출
    
    public static CarInfoTable CarInfoTable 
    {
        get { return Instance.carInfoTable;}
    }
    public static WallInfoTable WallInfoTable 
    {
        get { return Instance.wallInfoTable;}
    }
    public static RhythmInfoTable RhythmInfoTable 
    {
        get { return Instance.rhythmInfoTable;}
    }
    public static CheckPointInfoTable CheckPointInfoTable 
    {
        get { return Instance.checkPointInfoTable;}
    }
    public static ZombieInfoTable ZombieInfoTable 
    {
        get { return Instance.zombieInfoTable;}
    }
    public static SectionInfoTable SectionInfoTable 
    {
        get { return Instance.sectionInfoTable;}
    }

    private CarInfoTable carInfoTable = new CarInfoTable();
    private WallInfoTable wallInfoTable = new WallInfoTable();
    private RhythmInfoTable rhythmInfoTable = new RhythmInfoTable();
    private CheckPointInfoTable checkPointInfoTable = new CheckPointInfoTable();
    private ZombieInfoTable zombieInfoTable = new ZombieInfoTable();
    private SectionInfoTable sectionInfoTable = new SectionInfoTable();
}
