using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInfoTable : InfoTable<ZombieInfo>
{
    private string tableName = "ZombieTable";
    public ZombieInfoTable()
    {
        ZombieTable zombieTable = Resources.Load($"DataTable/{this.tableName}", typeof(ZombieTable)) as ZombieTable;
        foreach (var data in zombieTable.dataArray)
        {
            this.AddInfo(data);
        }
    }
    public void AddInfo(ZombieTableData _data)
    {   
        ZombieInfo zombieInfo = new ZombieInfo(_data);
        this.infoDictionary.Add(zombieInfo.id, zombieInfo);
    }
}
