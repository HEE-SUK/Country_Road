using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointInfoTable : InfoTable<CheckPointInfo>
{
    private string tableName = "CheckPointTable";
    public CheckPointInfoTable()
    {
        CheckPointTable checkPointTable = Resources.Load($"DataTable/{this.tableName}", typeof(CheckPointTable)) as CheckPointTable;
        foreach (var data in checkPointTable.dataArray)
        {
            this.AddInfo(data);
        }
    }

    public void AddInfo(CheckPointTableData _data)
    {   
        CheckPointInfo checkPointInfo = new CheckPointInfo(_data);
        this.infoDictionary.Add(checkPointInfo.id, checkPointInfo);
    }
}
