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
    public static BoosterInfoTable BoosterInfoTable 
    {
        get { return Instance.boosterInfoTable;}
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
    public static LocalizeInfoTable LocalizeInfoTable 
    {
        get { return Instance.localizeInfoTable;}
    }

    private CarInfoTable carInfoTable = new CarInfoTable();
    private WallInfoTable wallInfoTable = new WallInfoTable();
    private BoosterInfoTable boosterInfoTable = new BoosterInfoTable();
    private CheckPointInfoTable checkPointInfoTable = new CheckPointInfoTable();
    private ZombieInfoTable zombieInfoTable = new ZombieInfoTable();
    private SectionInfoTable sectionInfoTable = new SectionInfoTable();
    private LocalizeInfoTable localizeInfoTable =  new LocalizeInfoTable();
}
