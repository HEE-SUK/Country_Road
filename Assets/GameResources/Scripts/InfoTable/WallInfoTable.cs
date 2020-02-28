using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallInfoTable : InfoTable<WallInfo>
{
    private string tableName = "WallTable";
    public WallInfoTable()
    {
        WallTable wallTable = Resources.Load($"DataTable/{this.tableName}", typeof(WallTable)) as WallTable;
        foreach (var data in wallTable.dataArray)
        {
            this.AddInfo(data);
        }
    }
    public void AddInfo(WallTableData _data)
    {   
        WallInfo wallInfo = new WallInfo(_data);
        this.infoDictionary.Add(wallInfo.id, wallInfo);
    }
}
